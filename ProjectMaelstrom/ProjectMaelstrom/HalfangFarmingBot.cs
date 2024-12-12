using ProjectMaelstrom.Modules.ImageRecognition;
using ProjectMaelstrom.Utilities;
using System.Runtime.InteropServices;
using System.Timers;

namespace ProjectMaelstrom;

public partial class HalfangFarmingBot : Form
{
    [DllImport("user32.dll", SetLastError = true)]
    public static extern short GetAsyncKeyState(int vKey);

    [DllImport("user32.dll")]
    private static extern IntPtr GetMessageExtraInfo();

    private System.Timers.Timer _runTimer;

    private bool _botRun = false;

    private readonly PlayerController _playerController = new PlayerController();
    private readonly CombatUtils _combatUtils = new CombatUtils();

    private bool _joiningDungeon = false;
    private bool _inDungeon = false;
    private bool _battleStarted = false;
    private bool _battleWon = false;
    private bool _botStarted = false;

    private bool _isRunning = false;

    public HalfangFarmingBot()
    {
        InitializeComponent();
        CheckForIllegalCrossThreadCalls = false;
    }

    private void HalfangFarmingBot_Load(object sender, EventArgs e) { }

    private void DungeonLoop(object? sender, ElapsedEventArgs e)
    {
        if (_isRunning)
        {
            return;
        }

        _isRunning = true;

        if (_combatUtils.IsOutsideDungeon() && !_joiningDungeon && !_inDungeon)
        {
            UpdateBotState("Outside dungeon joining");
            HandleJoinDungeon();
        }
        else if (_inDungeon && !_battleStarted && !_battleWon)
        {
            UpdateBotState("Battle not started joining");
            _playerController.MoveForward();

            while (!_battleStarted)
            {
                if (_combatUtils.IsInBattle())
                {
                    _battleStarted = true;
                }
            }
        }
        else if (_battleStarted && !_battleWon)
        {
            if (_combatUtils.IsMyTurn())
            {
                HandleMyTurn();
            }
            else
            {
                UpdateBotState("Waiting for turn");
            }

            Point? spellbook = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/General/spellbook.png");

            if (spellbook != null)
            {
                HandleBattleOver();
            }
        }
        else if (_battleWon)
        {
            HandleBattleWon();
        }

        _isRunning = false;
    }

    private void HandleJoinDungeon()
    {
        UpdateJoiningDungeonState(true);
        UpdateBotState("Outside dungeon joining");
        GeneralUtils.Instance.ResetCursorPosition();
        _playerController.Interact();

        Point? loadingIcon = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Halfang/loading.png");

        while (loadingIcon == null)
        {
            loadingIcon = ImageFinder.RetrieveTargetImagePositionInScreenshot($"{StorageUtils.GetAppPath()}/Halfang/loading.png");
        }

        if (loadingIcon.HasValue)
        {
            UpdateJoiningDungeonState(false);
            UpdateInDungeonState(true);
        }
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

        GeneralUtils.Instance.ResetCursorPosition();
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
        bool teleported = GeneralUtils.Instance.Teleport();
        
        if (teleported)
        {
            GeneralUtils.Instance.ResetCursorPosition();
            UpdateBattleWonState(false);
            UpdateInDungeonState(false);
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        if (!_botStarted)
        {
            _runTimer = new System.Timers.Timer(TimeSpan.FromMilliseconds(200));
            _runTimer.Elapsed += DungeonLoop;
            _runTimer.AutoReset = true;
            _runTimer.Start();
            _botStarted = true;
            button1.Text = "Stop Bot";
        }
        else
        {
            _runTimer?.Stop();
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

    private void UpdateInDungeonState(bool state)
    {
        _inDungeon = state;
        inDungeonText.Text = state ? "True" : "False";
        inDungeonText.ForeColor = state ? Color.DarkGreen : Color.Red;
    }

    private void UpdateBotState(string state)
    {
        botState.Text = state;
    }
}
