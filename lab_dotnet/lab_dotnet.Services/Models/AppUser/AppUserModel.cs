namespace lab_dotnet.Services.Models;

public class AppUserModel : BaseModel
{
    public string FullName { get; set; }
    public Guid JobTitleId { get; set; }
    public int AccessLevel { get; set; }
    public string Email { get; set; }
}