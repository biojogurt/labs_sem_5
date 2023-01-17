using lab_dotnet.WebAPI.MapperProfile;

namespace lab_dotnet.WebAPI.AppConfiguration.ServicesExtensions;

public static partial class ServicesExtensions
{
    /// <summary>
    /// Add mappper configuration
    /// </summary>
    /// <param name="services"></param>
    public static void AddMapperConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(PresentationProfile));
    }
}