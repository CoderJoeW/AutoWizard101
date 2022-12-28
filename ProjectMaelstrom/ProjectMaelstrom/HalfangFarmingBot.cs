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
using static System.Windows.Forms.AxHost;

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

        private bool _joiningDungeon = false;
        private bool _battleStarted = false;
        private bool _battleWon = false;

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
                    HandleJoinDungeon();
                    continue;
                }

                if(!IsBattleStarted())
                {
                    HandleInDungeonBattleNotStarted();
                    continue;
                }

                if (_combatUtils.IsInBattle())
                {

                    if (_combatUtils.IsMyTurn())
                    {
                        HandleMyTurn();
                        continue;
                    }
                    else
                    {
                        botState.Text = "Waiting for turn";
                    }
                }
                else
                {
                    HandleBattleOver();
                }

                if (_battleWon)
                {
                    HandleBattleWon();
                }
            }
        }

        private bool IsBattleStarted()
        {
            Point bristlecrown = _image_recognition.GetImageLocation($"{StorageUtils.GetAppPath()}/Halfang/bristlecrown.png");

            if(bristlecrown.X > 0 && bristlecrown.Y > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void HandleJoinDungeon()
        {
            _joiningDungeon = true;
            joiningDungeonText.Text = "True";
            joiningDungeonText.ForeColor = Color.DarkGreen;

            botState.Text = "Outside dungeon joining";
            GeneralUtils.Instance.SetMarker();
            _combatUtils.ResetCursor();
            _playerController.Interact();

            _joiningDungeon = false;
            joiningDungeonText.Text = "False";
            joiningDungeonText.ForeColor = Color.Red;
        }

        private void HandleInDungeonBattleNotStarted()
        {
            botState.Text = "Battle not started joining";
            _playerController.MoveForward();
        }

        private void HandleMyTurn()
        {
            ChangeBattleState(true);

            botState.Text = "My turn";
            bool result = _combatUtils.UseCard("meteor");

            if (!result)
            {
                _combatUtils.Pass();
            }

            _combatUtils.ResetCursor();
        }

        private void HandleBattleOver()
        {
            if (_battleStarted)
            {
                botState.Text = "Battle won";
                ChangeBattleState(false);
                ChangeBattleWonState(true);
            }
        }

        private void HandleBattleWon()
        {
            botState.Text = "Battle won teleporting to start";

            bool teleported = GeneralUtils.Instance.Teleport();
            
            if (teleported)
            {
                _combatUtils.ResetCursor();
                ChangeBattleWonState(false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _halfangBot = new Thread(DungeonLoop);
            _halfangBot.Name = "Halfang Bot";
            _botRun = true;
            _halfangBot.Start();
        }

        private void ChangeBattleState(bool state)
        {
            _battleStarted = state;

            if (state)
            {
                inBattleText.Text = "True";
                inBattleText.ForeColor = Color.DarkGreen;
            }
            else
            {
                inBattleText.Text = "False";
                inBattleText.ForeColor = Color.Red;
            }
        }

        private void ChangeBattleWonState(bool state)
        {
            _battleWon = state;

            if (state)
            {
                battleWonText.Text = "True";
                battleWonText.ForeColor = Color.DarkGreen;
            }
            else
            {
                battleWonText.Text = "False";
                battleWonText.ForeColor = Color.Red;
            }
        }
    }
}
