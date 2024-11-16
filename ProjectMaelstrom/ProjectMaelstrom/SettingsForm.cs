namespace ProjectMaelstrom;

public partial class SettingsForm : Form
{
    public SettingsForm()
    {
        InitializeComponent();
    }

    private void SettingsForm_Load(object sender, EventArgs e)
    {
        ocrSpaceApiKey.Text = Properties.Settings.Default["OCR_SPACE_APIKEY"].ToString();
    }

    private void saveSettingsBtn_Click(object sender, EventArgs e)
    {
        Properties.Settings.Default["OCR_SPACE_APIKEY"] = ocrSpaceApiKey.Text;
        Properties.Settings.Default["GAME_RESOLUTION"] = selectedGameResolution.Text;

        Properties.Settings.Default.Save();

        StateManager.Instance.SelectedResolution = selectedGameResolution.Text;

        this.Close();
    }
}
