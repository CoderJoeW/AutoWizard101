using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectMaelstrom
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            ocrSpaceApiKey.Text = Properties.Settings.Default["OCR_SPACE_APIKEY"].ToString();
        }

        private void saveSettingsBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["OCR_SPACE_APIKEY"] = ocrSpaceApiKey.Text;

            Properties.Settings.Default.Save();

            this.Close();
        }
    }
}
