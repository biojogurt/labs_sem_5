using System.Data;
using lab_dotnet.Entities.Models;

namespace lab_dotnet.Services.Models;

public class RegisterUserModel
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string FullName { get; set; }
    public Guid JobTitleId { get; set; }
    public int AccessLevel { get; set; }
}