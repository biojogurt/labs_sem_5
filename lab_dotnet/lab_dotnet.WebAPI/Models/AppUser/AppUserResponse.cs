namespace lab_dotnet.WebAPI.Models;

public class AppUserResponse : BaseResponse
{
    public string FullName { get; set; }
    public Guid JobTitleId { get; set; }
    public int AccessLevel { get; set; }
    public string Email { get; set; }
}