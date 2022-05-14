using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectMaelstrom
{
    public partial class BazaarReagentBot : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern short GetAsyncKeyState(int vKey);

        private ImageRecognition _image_recognition = new ImageRecognition();
        private Thread _bazaarBot;
        private bool _botRun = false;

        public BazaarReagentBot()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CheckForIllegalCrossThreadCalls = false;

            string[] reagents = Directory.GetDirectories($"{resolutionSelector.Text}/Bazaar/BazaarReagents/").Select(d => new DirectoryInfo(d).Name).ToArray();
            reagents.OrderBy(x => x);

            availableReagents.Items.Clear();

            for (int i = 0; i < reagents.Length; i++)
            {
                availableReagents.Items.Add(Char.ToUpper(reagents[i][0]) + reagents[i].Substring(1));
            }

            Task.Run(() => UpdateMouse());
        }

        private void UpdateMouse()
        {
            while (true)
            {
                if (this.WindowState == FormWindowState.Normal)
                {
                    //xLabel.Text = "X: " + Cursor.Position.X;
                    //yLabel.Text = "Y: " + Cursor.Position.Y;
                    Thread.Sleep(10);
                }

                if (GetAsyncKeyState(0x70) != 0)
                {
                    _botRun = false;
                }
            }
        }

        private void RunBot()
        {
            while (_botRun)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();

                List<string> searchForReagents = purchaseReagents.Items.Cast<string>().ToList();

                for (int i = 0; i < searchForReagents.Count; i++)
                {
                    ReagentLoop(searchForReagents[i]);
                }
            }
        }

        private void ReagentLoop(string reagentName)
        {
            bool found = FindReagent(reagentName);

            if (found)
            {
                BuyReagent();
            }

            RefreshBazaar();
            IsLoading();
        }

        private bool FindReagent(string reagentName)
        {
            string[] images = Directory.GetFiles($"{resolutionSelector.Text}/Bazaar/BazaarReagents/{reagentName.ToLower()}/");
            bool foundReagent = false;
            bool maxPages = false;

            while (!maxPages)
            {
                for (int i = 0; i < images.Length; i++)
                {
                    if (!foundReagent)
                    {
                        Point reagent = _image_recognition.GetImageLocation(images[i]);

                        if (reagent.X > 0 && reagent.Y > 0)
                        {
                            WinAPI.click(reagent);
                            foundReagent = true;
                            maxPages = true;
                        }
                    }
                }

                maxPages = (maxPages ? true : NextPage());
            }

            return foundReagent;
        }

        private bool NextPage()
        {
            bool maxPages = false;

            Point nextPageBtn = _image_recognition.GetImageLocation($"{resolutionSelector.Text}/Bazaar/BazaarUtils/nextpage.png");

            if (nextPageBtn.X > 0 && nextPageBtn.Y > 0)
            {
                WinAPI.click(nextPageBtn);

                Thread.Sleep(100);

                ResetCursor();
            }
            else
            {
                maxPages = true;
            }

            return maxPages;
        }

        private void BuyReagent()
        {
            Point buyBtn = _image_recognition.GetImageLocation($"{resolutionSelector.Text}/Bazaar/BazaarUtils/buybutton.png");

            if (buyBtn.X > 0 && buyBtn.Y > 0)
            {
                WinAPI.click(buyBtn);

                Thread.Sleep(1000);

                Point yesBtn = _image_recognition.GetImageLocation($"{resolutionSelector.Text}/Bazaar/BazaarUtils/yesbutton.png");

                if (yesBtn.X > 0 && yesBtn.Y > 0)
                {
                    WinAPI.click(yesBtn);

                    Thread.Sleep(100);
                }
            }
        }

        private void RefreshBazaar()
        {
            Point refreshBtn = _image_recognition.GetImageLocation($"{resolutionSelector.Text}/Bazaar/BazaarUtils/refresh.png");

            if (refreshBtn.X > 0 && refreshBtn.Y > 0)
            {
                WinAPI.click(refreshBtn);
                ResetCursor();
            }
        }

        private void IsLoading()
        {
            bool isLoading = false;

            Point loadingIndicator = _image_recognition.GetImageLocation($"{resolutionSelector.Text}/Bazaar/BazaarUtils/loading.png");

            isLoading = (loadingIndicator.X > 0 && loadingIndicator.Y > 0 ? true : false);

            while (isLoading)
            {
                loadingIndicator = _image_recognition.GetImageLocation($"{resolutionSelector.Text}/Bazaar/BazaarUtils/loading.png");

                isLoading = (loadingIndicator.X > 0 && loadingIndicator.Y > 0 ? true : false);
            }
        }

        private void ResetCursor()
        {
            Point blankSpot = _image_recognition.GetImageLocation($"{resolutionSelector.Text}/Bazaar/BazaarUtils/blank.png");

            if (blankSpot.X > 0 && blankSpot.Y > 0)
            {
                WinAPI.click(blankSpot);
            }
            else
            {
                WinAPI.click(new Point(50, 20));
            }
        }

        private void availableReagents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (availableReagents.GetItemText(availableReagents.SelectedItem) != "")
            {
                string currItem = availableReagents.GetItemText(availableReagents.SelectedItem);
                availableReagents.Items.RemoveAt(availableReagents.SelectedIndex);
                purchaseReagents.Items.Add(currItem);
            }
        }

        private void purchaseReagents_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (purchaseReagents.GetItemText(purchaseReagents.SelectedItem) != "")
            {
                string currItem = purchaseReagents.GetItemText(purchaseReagents.SelectedItem);
                purchaseReagents.Items.RemoveAt(purchaseReagents.SelectedIndex);
                availableReagents.Items.Add(currItem);
            }
        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            _bazaarBot = new Thread(RunBot);
            _bazaarBot.Name = "Bazaar Bot";
            _botRun = true;
            _bazaarBot.Start();
        }
    }
}