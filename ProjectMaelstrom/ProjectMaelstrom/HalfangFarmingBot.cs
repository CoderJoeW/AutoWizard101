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
        private GeneralUtils _generalUtils = new GeneralUtils();

        private bool battleStarted = false;

        public HalfangFarmingBot()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            
        }

        private void HalfangFarmingBot_Load(object sender, EventArgs e){}

        private void DungeonLoop()
        {
            while (_botRun)
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();

                if (_combatUtils.IsOutsideDungeon())
                {
                    botState.Text = "Outside dungeon joining";
                    _playerController.Interact();
                }

                if(!IsBattleStarted())
                {
                    botState.Text = "Battle not started joining";
                    _playerController.MoveForward();
                }

                if (_combatUtils.IsInBattle())
                {
                    battleStarted= true;

                    if (_combatUtils.IsMyTurn())
                    {
                        botState.Text = "My turn";
                        bool result = _combatUtils.UseCard("meteor");

                        if (!result)
                        {
                            _combatUtils.Pass();
                        }

                        _combatUtils.ResetCursor();
                    }
                    else
                    {
                        botState.Text = "Waiting for turn";
                    }
                }
                else
                {
                    if (battleStarted)
                    {
                        botState.Text = "Battle won";
                        battleStarted = false;
                    }
                }
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
            _halfangBot = new Thread(DungeonLoop);
            _halfangBot.Name = "Halfang Bot";
            _botRun = true;
            _halfangBot.Start();
        }
    }
}
