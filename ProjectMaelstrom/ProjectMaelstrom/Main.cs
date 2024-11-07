using System.Timers;
using Timer = System.Timers.Timer;

using ProjectMaelstrom.Modules.ImageRecognition;
using ProjectMaelstrom.Utilities;

namespace ProjectMaelstrom
{
    public partial class Main : Form
    {
        private Timer _manaRefreshTimer;

        public Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _manaRefreshTimer = new Timer(TimeSpan.FromSeconds(10));
            _manaRefreshTimer.Elapsed += _refreshManaTimer_Elapsed;
            _manaRefreshTimer.AutoReset = true;
            _manaRefreshTimer.Start();

            StateManager.Instance.SelectedResolution = "1280x720";
        }

        private void _refreshManaTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            manaAmountLabel.Text = $"{StateManager.Instance.CurrentMana.ToString()}/{StateManager.Instance.MaxMana.ToString()}";
        }

        private void editSettingsBtn_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.TopMost = true;
            settingsForm.Show();
        }

        private async void startConfigurationBtn_Click(object sender, EventArgs e)
        {
            while (!GeneralUtils.Instance.IsGameVisible())
            {
                GeneralUtils.Instance.OpenGameWindow();
                Thread.Sleep(500);
            }

            while (!GeneralUtils.Instance.IsStatsPageVisible())
            {
                GeneralUtils.Instance.OpenStatsWindow();
                Thread.Sleep(500);
            }

            string imagePath = ImageFinder.CaptureScreen();

            string extractedText = await ImageHelpers.ExtractTextFromImage(imagePath);

            string[] extractedTextArray = extractedText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            string mana = "";

            for (int i = 0; i < extractedTextArray.Length; i++)
            {
                if (extractedTextArray[i] == "GOLD")
                {
                    mana = extractedTextArray[i - 1];
                }
            }

            string[] manaArray = mana.Split(new[] { "/" }, StringSplitOptions.None);

            StateManager.Instance.CurrentMana = int.Parse(manaArray[0]);
            StateManager.Instance.MaxMana = int.Parse(manaArray[1]);
        }

        private void loadHalfangBotBtn_Click(object sender, EventArgs e)
        {
            HalfangFarmingBot halfangFarmingBot = new HalfangFarmingBot();
            halfangFarmingBot.TopLevel = false;
            halfangFarmingBot.FormBorderStyle = FormBorderStyle.None;

            panel2.Controls.Add(halfangFarmingBot);
            halfangFarmingBot.Show();
        }
    }
}
