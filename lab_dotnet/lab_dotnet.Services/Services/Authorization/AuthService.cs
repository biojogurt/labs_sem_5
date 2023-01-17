using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using IdentityModel.Client;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Models;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Exceptions;
using lab_dotnet.Exceptions.ResultCodes;

namespace lab_dotnet.Services.Implementation;

public class AuthService : IAuthService
{
    private readonly UserManager<AppUser> userManager;
    private readonly SignInManager<AppUser> signInManager;
    private readonly IMapper mapper;
    private readonly string identityUri;

    public AuthService(
        UserManager<AppUser> userManager,
        SignInManager<AppUser> signInManager,
        IMapper mapper,
        IConfiguration configuration
    )
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.mapper = mapper;
        identityUri = configuration.GetValue<string>("IdentityServer:Uri") ?? "";
    }

    public async Task<AppUserModel> RegisterUser(RegisterUserModel model)
    {
        var existingUser = await userManager.FindByEmailAsync(model.Email);
        if (existingUser != null)
        {
            throw new LogicException(ResultCode.USER_ALREADY_EXISTS);
        }

        var user = new AppUser()
        {
            Email = model.Email,
            UserName = model.Email,
            FullName = model.FullName,
            JobTitleId = model.JobTitleId,
            AccessLevel = model.AccessLevel,
            EmailConfirmed = true
        };

        var result = await userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            throw new LogicException(ResultCode.IDENTITY_SERVER_ERROR);
        }

        var createdUser = await userManager.FindByEmailAsync(model.Email);
        return mapper.Map<AppUserModel>(createdUser);
    }

    public async Task<TokenResponse> LoginUser(LoginUserModel model)
    {
        var user = await userManager.FindByEmailAsync(model.Email);
        if (user == null)
        {
            throw new LogicException(ResultCode.USER_NOT_FOUND);
        }

        var result = await signInManager.CheckPasswordSignInAsync(user, model.Password, false);
        if (!result.Succeeded)
        {
            throw new LogicException(ResultCode.EMAIL_OR_PASSWORD_IS_INCORRECT);
        }

        var client = new HttpClient();
        var disco = await client.GetDiscoveryDocumentAsync(identityUri);
        if (disco.IsError)
        {
            throw new Exception(disco.Error);
        }

        var tokenResponse = await client.RequestPasswordTokenAsync(new PasswordTokenRequest
        {
            Address = disco.TokenEndpoint,
            ClientId = model.ClientId,
            ClientSecret = model.ClientSecret,
            UserName = model.Email,
            Password = model.Password,
            Scope = "api"
        });

        return tokenResponse.IsError ? throw new LogicException(ResultCode.IDENTITY_SERVER_ERROR) : tokenResponse;
    }
}