using static ProjectMaelstrom.Structs.InputStructs;
using System.Runtime.InteropServices;
using ProjectMaelstrom.Modules.ImageRecognition;

namespace ProjectMaelstrom
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern uint SendInput(uint nInputs, Input[] pInputs, int cbSize);

        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        private ImageRecognition _image_recognition = new ImageRecognition();
        private Thread _halfangBot;
        private bool _botRun = false;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}