using System;
using lab_dotnet.Entities.Models;
using lab_dotnet.Repository;
using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Models;
using Microsoft.AspNetCore.Identity;

namespace lab_dotnet.WebAPI.AppConfiguration;

public static class RepositoryInitializer
{
    public const string MASTER_ADMIN_EMAIL = "master@mail.ru";
    public const string MASTER_ADMIN_PASSWORD = "123456";

    private static async Task CreateGlobalAdmin(IAuthService authService)
    {
        await authService.RegisterUser(new RegisterUserModel()
        {
            Email = MASTER_ADMIN_EMAIL,
            Password = MASTER_ADMIN_PASSWORD,
            FullName = "Boss Baby",
            JobTitleId = Guid.Parse("D65C77E5-18B5-4E99-93B6-EFADED7F0FFD"),
            AccessLevel = 1
        });
    }

    public static async Task InitializeRepository(IApplicationBuilder app)
    {
        using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>()?.CreateScope())
        {
            if (scope != null)
            {
                var userManager = (UserManager<AppUser>) scope.ServiceProvider.GetRequiredService(typeof(UserManager<AppUser>));
                var user = await userManager.FindByEmailAsync(MASTER_ADMIN_EMAIL);
                if (user == null)
                {
                    var authService = (IAuthService) scope.ServiceProvider.GetRequiredService(typeof(IAuthService));
                    await CreateGlobalAdmin(authService);
                }
            }
        }
    }
}