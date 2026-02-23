namespace Mission8_Team.Models;

// we can keep this model just to keep errors cleaner.
public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}

