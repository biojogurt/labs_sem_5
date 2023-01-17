using lab_dotnet.Services.Abstract;
using lab_dotnet.Services.Implementation;
using lab_dotnet.Services.MapperProfile;
using Microsoft.Extensions.DependencyInjection;

namespace lab_dotnet.Services;

public static partial class ServicesExtensions
{
    public static void AddServicesConfiguration(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServicesProfile));

        //services
        services.AddScoped(typeof(IPageService<,>), typeof(PageService<,>));
        services.AddScoped<IAppUserService, AppUserService>();
        services.AddScoped<IAuthService, AuthService>();
        services.AddScoped<IBorrowerService, BorrowerService>();
        services.AddScoped<IContributionService, ContributionService>();
        services.AddScoped<IContributorService, ContributorService>();
        services.AddScoped<ICreditApplicationService, CreditApplicationService>();
        services.AddScoped<ICreditorService, CreditorService>();
        services.AddScoped<ICreditService, CreditService>();
        services.AddScoped<ICreditTypeService, CreditTypeService>();
        services.AddScoped<IJobTitleService, JobTitleService>();
        services.AddScoped<IPassportIssuerService, PassportIssuerService>();
        services.AddScoped<IPaymentService, PaymentService>();
        services.AddScoped<IRequesterService, RequesterService>();
        services.AddScoped<IRequestService, RequestService>();
    }
}