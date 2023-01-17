using lab_dotnet.Entities.Models;

namespace lab_dotnet.Services.Models;

public class LoginUserModel
{
    public string ClientId { get; set; }
    public string ClientSecret { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}