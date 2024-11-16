using ProjectMaelstrom.Modules.ImageRecognition;
using ProjectMaelstrom.Utilities;
using System.Data;
using System.Drawing.Text;
using System.Threading;
using System.Timers;

namespace ProjectMaelstrom
{
    public partial class BazaarReagentBot : Form
    {
        private System.Timers.Timer _runTimer;

        private bool _botStarted = false;

        private bool _isRunning = false;

        public BazaarReagentBot()
        {
            InitializeComponent();
            LoadPngFiles();
        }

        private void LoadPngFiles()
        {
            string directoryPath = $"{StorageUtils.GetAppPath()}/Bazaar/Reagents";

            if (Directory.Exists(directoryPath))
            {
                var fileNames = Directory.GetFiles(directoryPath, "*.png")
                                         .Select(Path.GetFileNameWithoutExtension)
                                         .ToList();

                listBox1.SelectionMode = SelectionMode.MultiSimple;
                listBox1.Items.Clear();
                listBox1.Items.AddRange(fileNames.ToArray());
            }
            else
            {
                MessageBox.Show("Directory not found: " + directoryPath, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            if (!_botStarted)
            {
                _runTimer = new System.Timers.Timer(TimeSpan.FromMilliseconds(200));
                _runTimer.Elapsed +=BazaarLoop;
                _runTimer.AutoReset = true;
                _runTimer.Start();
                _botStarted = true;
                btn.Text = "Stop Bot";
            }
            else
            {
                _runTimer?.Stop();
                _botStarted = false;
                btn.Text = "Start Bot";
            }
        }

        private void BazaarLoop(object? sender, ElapsedEventArgs e)
        {
            if (_isRunning)
            {
                return;
            }

            _isRunning = true;

            RefreshShop();

            if (listBox1.SelectedItems.Count > 0)
            {
                foreach (var item in listBox1.SelectedItems)
                {
                    string? selectedName = item.ToString();

                    if (selectedName == null)
                    {
                        continue;
                    }

                    GetReagentLocation(selectedName);
                }
            }

            _isRunning = false;
        }

        private void GetReagentLocation(string itemName)
        {
            Point? item = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Bazaar/Reagents/{itemName}.png");

            if (item.HasValue)
            {
                label1.Text = "Found item";
                WinAPI.click(item.Value);
                BuyReagent();
            }
            else
            {
                label1.Text = "Not ofund";
            }
        }

        private void BuyReagent()
        {
            Point? buyBtn = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Bazaar/buybtn.png");

            while (buyBtn == null)
            {
                buyBtn = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Bazaar/buybtn.png");
            }

            if (buyBtn.HasValue)
            {
                WinAPI.click(buyBtn.Value);

                Point? yesBtn = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Bazaar/yesBtn.png");
                Point? okBtn = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Bazaar/okBtn.png");

                while (yesBtn == null && okBtn == null)
                {
                    yesBtn = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Bazaar/yesBtn.png");
                    okBtn = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Bazaar/okBtn.png");
                }

                if (yesBtn.HasValue)
                {
                    WinAPI.click(yesBtn.Value);
                }

                if (okBtn.HasValue)
                {
                    WinAPI.click(okBtn.Value);
                }
            }
        }

        private void RefreshShop()
        {
            Point? refreshBtn = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Bazaar/refreshBtn.png");

            while (refreshBtn == null)
            {
                refreshBtn = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Bazaar/refreshBtn.png");
            }

            if (refreshBtn.HasValue)
            {
                WinAPI.click(refreshBtn.Value);
            }
        }

        private void BazaarReagentBot_Load(object sender, EventArgs e)
        {

        }
    }
}
