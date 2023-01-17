using lab_dotnet.Services.Models;
using IdentityModel.Client;

namespace lab_dotnet.Services.Abstract;

public interface IAuthService
{
    Task<AppUserModel> RegisterUser(RegisterUserModel model);
    Task<TokenResponse> LoginUser(LoginUserModel model);
}