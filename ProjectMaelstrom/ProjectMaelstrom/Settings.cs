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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void saveSettingsBtn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default["Lazarus_Organization_Id"] = lazarusOrgId.Text;
            Properties.Settings.Default["Lazarus_Auth_Key"] = lazarusAuthKey.Text;
            this.Close();
        }
    }
}
