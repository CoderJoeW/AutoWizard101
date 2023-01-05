using Newtonsoft.Json;
using ProjectMaelstrom.Models;
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
    public partial class testing : Form
    {
        public testing()
        {
            InitializeComponent();
        }

        private async void testing_Load(object sender, EventArgs e)
        {
            OcrResultModel result = await ImageToText.GetStringsFromImage("test.png");

            List<string> testSplit = result.ParsedResults[0].ParsedText.Split("\n").ToList();

            for(int i = 0; i < testSplit.Count; i++)
            {
                if (testSplit[i] == "MANA")
                {
                    richTextBox1.Text = testSplit[i+2];
                }
            }
        }
    }
}
