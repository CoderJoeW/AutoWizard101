namespace ProjectMaelstrom.Models;

public class ParsedResult
{
    public TextOverlay TextOverlay { get; set; }
    public string TextOrientation { get; set; }
    public int FileParseExitCode { get; set; }
    public string ParsedText { get; set; }
    public string ErrorMessage { get; set; }
    public string ErrorDetails { get; set; }
}

public class OcrResultModel
{
    public List<ParsedResult> ParsedResults { get; set; }
    public int OCRExitCode { get; set; }
    public bool IsErroredOnProcessing { get; set; }
    public string ProcessingTimeInMilliseconds { get; set; }
    public string SearchablePDFURL { get; set; }
}

public class TextOverlay
{
    public List<object> Lines { get; set; }
    public bool HasOverlay { get; set; }
    public string Message { get; set; }
}
