namespace ProjectMaelstrom;

internal class StateManager
{
    private static StateManager? _instance;

    public static StateManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance= new StateManager();
            }

            return _instance;
        }
    }

    public string? SelectedResolution { set; get; } = "1280x720";

    public int CurrentMana { set; get; }
    public int MaxMana { set; get; }

    public int SetMarkerCost { set; get; }
}
