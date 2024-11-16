namespace ProjectMaelstrom.Utilities;

internal class StorageUtils
{
    public static string GetAppPath()
    {
        return $"Resources/{StateManager.Instance.SelectedResolution}";
    }
}
