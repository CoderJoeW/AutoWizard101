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
    public partial class Main : Form
    {
        private StateManager _stateManager;

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _stateManager= new StateManager();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _stateManager.SelectedResolution = resolutionSelector.SelectedText;
        }
    }
}
