using System.Runtime.InteropServices;
using ProjectMaelstrom.Modules.ImageRecognition;
using ProjectMaelstrom.Utilities;

namespace ProjectMaelstrom
{
    public partial class HalfangFarmingBot : Form
    {
        [DllImport("user32.dll", SetLastError = true)]
        public static extern short GetAsyncKeyState(int vKey);

        [DllImport("user32.dll")]
        private static extern IntPtr GetMessageExtraInfo();

        private Thread _halfangBot;
        private bool _botRun = false;

        private readonly PlayerController _playerController = new PlayerController();
        private readonly CombatUtils _combatUtils = new CombatUtils();

        private bool _joiningDungeon = false;
        private bool _battleStarted = false;
        private bool _battleWon = false;
        private bool _botStarted = false;

        public HalfangFarmingBot()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        private void HalfangFarmingBot_Load(object sender, EventArgs e) { }

        private void DungeonLoop()
        {
            while (_botRun)
            {

                if (_combatUtils.IsOutsideDungeon())
                {
                    HandleJoinDungeon();
                }
                else if (!IsBattleStarted())
                {
                    HandleInDungeonBattleNotStarted();
                }
                else if (_combatUtils.IsInBattle())
                {
                    if (_combatUtils.IsMyTurn())
                    {
                        HandleMyTurn();
                    }
                    else
                    {
                        UpdateBotState("Waiting for turn");
                    }
                }
                else
                {
                    HandleBattleOver();

                    if (_battleWon)
                    {
                        HandleBattleWon();
                    }
                }
            }
        }

        private bool IsBattleStarted()
        {
            Point? bristlecrown = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Halfang/bristlecrown.png");

            if (bristlecrown.HasValue)
            {
                return false;
            }

            return true;
        }

        private void HandleJoinDungeon()
        {
            UpdateJoiningDungeonState(true);
            UpdateBotState("Outside dungeon joining");
            GeneralUtils.Instance.SetMarker();
            _combatUtils.ResetCursorPosition();
            _playerController.Interact();
            UpdateJoiningDungeonState(false);
        }

        private void HandleInDungeonBattleNotStarted()
        {
            UpdateBotState("Battle not started joining");
            _playerController.MoveForward();
        }

        private void HandleMyTurn()
        {
            UpdateBattleState(true);
            UpdateBotState("My turn");
            bool result = _combatUtils.UseCard("meteor");

            if (!result)
            {
                _combatUtils.Pass();
            }

            _combatUtils.ResetCursorPosition();
        }

        private void HandleBattleOver()
        {
            if (_battleStarted)
            {
                UpdateBotState("Battle won");
                UpdateBattleState(false);
                UpdateBattleWonState(true);
            }
        }

        private void HandleBattleWon()
        {
            UpdateBotState("Battle won teleporting to start");
            bool teleported = GeneralUtils.Instance.Teleport();

            if (teleported)
            {
                _combatUtils.ResetCursorPosition();
                UpdateBattleWonState(false);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!_botStarted)
            {
                _halfangBot = new Thread(DungeonLoop);
                _halfangBot.Name = "Halfang Bot";
                _botRun = true;
                _halfangBot.Start();
                _botStarted = true;
                button1.Text = "Stop Bot";
            }
            else
            {
                _botRun = false;
                _halfangBot.Join(); // Wait for the thread to finish
                _botStarted = false;
                button1.Text = "Start Bot";
            }
        }

        private void UpdateBattleState(bool state)
        {
            _battleStarted = state;
            inBattleText.Text = state ? "True" : "False";
            inBattleText.ForeColor = state ? Color.DarkGreen : Color.Red;
        }

        private void UpdateBattleWonState(bool state)
        {
            _battleWon = state;
            battleWonText.Text = state ? "True" : "False";
            battleWonText.ForeColor = state ? Color.DarkGreen : Color.Red;
        }

        private void UpdateJoiningDungeonState(bool state)
        {
            _joiningDungeon = state;
            joiningDungeonText.Text = state ? "True" : "False";
            joiningDungeonText.ForeColor = state ? Color.DarkGreen : Color.Red;
        }

        private void UpdateBotState(string state)
        {
            botState.Text = state;
        }
    }
}
