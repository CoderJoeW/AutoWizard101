using ProjectMaelstrom.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace ProjectMaelstrom
{
    public partial class Main : Form
    {
        private Timer _refreshManaTimer;

        public Main()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _refreshManaTimer = new Timer(TimeSpan.FromSeconds(10));
            _refreshManaTimer.Elapsed +=_refreshManaTimer_Elapsed;
            _refreshManaTimer.AutoReset = true;
            _refreshManaTimer.Start();

            string resolution = Properties.Settings.Default["Resolution"].ToString();

            if (string.IsNullOrEmpty(resolution))
            {
                resolution = "1280x720";
            }

            resolutionSelector.Text = resolution;
            StateManager.Instance.SelectedResolution = resolution;
        }

        private void _refreshManaTimer_Elapsed(object? sender, ElapsedEventArgs e)
        {
            manaAmountLabel.Text = $"{StateManager.Instance.CurrentMana}/{StateManager.Instance.MaxMana}";
            richTextBox1.Text = StateManager.Instance.raw;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            StateManager.Instance.SelectedResolution = resolutionSelector.SelectedText;

            Properties.Settings.Default["Resolution"] = resolutionSelector.SelectedText;
            Properties.Settings.Default.Save();
        }

        private void editSettingsBtn_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm();
            sf.TopMost = true;
            sf.Show();
        }

        private void startConfigurationBtn_Click(object sender, EventArgs e)
        {
            GeneralUtils.Instance.GetUserMana();
        }
    }
}
