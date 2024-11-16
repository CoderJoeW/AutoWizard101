using ProjectMaelstrom.Modules.ImageRecognition;
using ProjectMaelstrom.Utilities;
using System.Data;
using System.Timers;

namespace ProjectMaelstrom;

public partial class BazaarReagentBot : Form
{
    private System.Timers.Timer _runTimer;

    private bool _botStarted = false;

    private bool _isRunning = false;

    private readonly PlayerController _playerController = new PlayerController();

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

        GeneralUtils.Instance.ResetCursorPosition();

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
        Point? buyMoreBtn = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Bazaar/buyMoreBtn.png");

        while (buyMoreBtn == null)
        {
            buyMoreBtn = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Bazaar/buyMoreBtn.png");
        }

        if (buyMoreBtn.HasValue)
        {
            WinAPI.click(buyMoreBtn.Value);

            Point? buyCount = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Bazaar/buyCount.png");

            while (buyCount == null)
            {
                buyCount = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Bazaar/buyCount.png");
            }

            if (buyCount.HasValue)
            {
                Point test = buyCount.Value;
                test.X += 10;
                WinAPI.click(test);
                _playerController.PressNumber9();
                _playerController.PressNumber9();
                _playerController.PressNumber9();
            }

            Point? buyBtn = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Bazaar/buyBtn.png");

            while (buyBtn == null)
            {
                buyBtn = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Bazaar/buyBtn.png");
            }

            if (buyBtn.HasValue)
            {
                WinAPI.click(buyBtn.Value);
            }

            Point? okBtn = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Bazaar/okBtn.png");

            while (okBtn == null)
            {
                okBtn = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Bazaar/okBtn.png");
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
}
