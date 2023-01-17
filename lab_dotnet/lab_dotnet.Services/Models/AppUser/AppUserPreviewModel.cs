namespace lab_dotnet.Services.Models;

public class AppUserPreviewModel : BasePreviewModel
{
    public string FullName { get; set; }
    public Guid JobTitleId { get; set; }
}