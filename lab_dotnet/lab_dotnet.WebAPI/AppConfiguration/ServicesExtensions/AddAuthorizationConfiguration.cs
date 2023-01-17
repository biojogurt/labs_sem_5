using lab_dotnet.Entities;
using lab_dotnet.Entities.Models;
using lab_dotnet.WebAPI.IdentityServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

namespace lab_dotnet.WebAPI.AppConfiguration.ServicesExtensions;

public static partial class ServicesExtensions
{
    /// <summary>
    /// Add authorization configuration
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static void AddAuthorizationConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        string? identityUri = configuration.GetValue<string>("IdentityServer:Uri");
        if (identityUri == null)
        {
            return;
        }

        services.AddIdentity<AppUser, UserRole>(options =>
        {
            options.SignIn.RequireConfirmedAccount = false;
            options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+!#$%&'*/=?^`{|}~";
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequiredUniqueChars = 0;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 6;
        })
        .AddEntityFrameworkStores<Context>()
        .AddSignInManager<SignInManager<AppUser>>()
        .AddDefaultTokenProviders();

        services.AddIdentityServer()
                .AddInMemoryApiScopes(IdentityServerDefaults.ApiScopes)
                .AddInMemoryClients(IdentityServerDefaults.Clients)
                .AddAspNetIdentity<AppUser>();

        services.AddAuthentication(options =>
        {
            options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
        {
            options.RequireHttpsMetadata = false;
            options.Authority = identityUri;
            options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
            {
                ValidateIssuerSigningKey = false,
                ValidateIssuer = false,
                ValidateAudience = false,
                RequireExpirationTime = true,
                ValidateLifetime = true,
                ClockSkew = TimeSpan.Zero
            };
            options.Audience = "api";
        });

        services.AddAuthorization();
    }
}