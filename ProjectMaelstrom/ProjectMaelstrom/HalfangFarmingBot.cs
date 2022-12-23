using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProjectMaelstrom.Utilities;

namespace ProjectMaelstrom
{
    public partial class HalfangFarmingBot : Form
    {

        [DllImport("user32.dll", SetLastError = true)]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        private ImageRecognition _image_recognition = new ImageRecognition();
        private Thread _halfangBot;
        private bool _botRun = false;

        private PlayerController _playerController = new PlayerController();
        private CombatUtils _combatUtils = new CombatUtils();

        public HalfangFarmingBot()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            
        }

        private void HalfangFarmingBot_Load(object sender, EventArgs e){}

        private void RunBot()
        {
            bool battleStarted = false;
            bool justTeleported = false;

            while (_botRun)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (IsOutside())
                {
                    botState.Text = "Outside joining";
                    _playerController.Interact();
                }
                
                if (!IsBattleStarted())
                {
                    botState.Text = "Joining Battle";
                    _playerController.MoveForward();
                }

                if (_combatUtils.IsInBattle() && _combatUtils.IsMyTurn())
                {
                    botState.Text = "In battle my turn";
                    battleStarted = true;
                    bool result = _combatUtils.UseCard("meteor");

                    if (!result)
                    {
                        //If we couldnt find the meteor card we pass
                        _combatUtils.Pass();
                    }

                    _combatUtils.ResetCursor();
                }
            }
        }

        private bool IsOutside()
        {
            Point sigil = _image_recognition.GetImageLocation($"{Constants.RESOLUTION}/Combat/Utils/sigil.png");

            if(sigil.X > 0 && sigil.Y > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool IsBattleStarted()
        {
            Point bristlecrown = _image_recognition.GetImageLocation($"{Constants.RESOLUTION}/Halfang/bristlecrown.png");

            if(bristlecrown.X > 0 && bristlecrown.Y > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _halfangBot = new Thread(RunBot);
            _halfangBot.Name = "Halfang Bot";
            _botRun = true;
            _halfangBot.Start();
        }
    }
}
