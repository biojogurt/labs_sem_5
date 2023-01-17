namespace lab_dotnet.WebAPI.AppConfiguration.ApplicationExtensions;

public static partial class AppExtensions
{
    /// <summary>
    /// Use authorization configuration
    /// </summary>
    /// <param name="app"></param>
    public static void UseAuthorizationConfiguration(this IApplicationBuilder app)
    {
        app.UseIdentityServer();
        app.UseAuthentication();
        app.UseAuthorization();
    }
}