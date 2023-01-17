namespace lab_dotnet.WebAPI.Models;

public class AppUserPreviewResponse : BaseResponse
{
    public string FullName { get; set; }
    public Guid JobTitleId { get; set; }
}