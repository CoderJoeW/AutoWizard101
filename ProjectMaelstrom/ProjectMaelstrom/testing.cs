using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tesseract;

namespace ProjectMaelstrom
{
    public partial class testing : Form
    {
        public testing()
        {
            InitializeComponent();
        }

        private async void testing_Load(object sender, EventArgs e)
        {
            string res = await ImageToText.Test("test.png");

            richTextBox1.Text = res;
        }
    }
}
