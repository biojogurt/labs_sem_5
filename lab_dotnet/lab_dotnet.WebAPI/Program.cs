using lab_dotnet.Services;
using lab_dotnet.Repository;
using lab_dotnet.WebAPI.AppConfiguration;
using lab_dotnet.WebAPI.AppConfiguration.ApplicationExtensions;
using lab_dotnet.WebAPI.AppConfiguration.ServicesExtensions;
using Serilog;
using lab_dotnet.WebAPI.AppConfiguration.Middlewares;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();

builder.AddSerilogConfiguration();
builder.Services.AddDbContextConfiguration(configuration);
builder.Services.AddVersioningConfiguration();
builder.Services.AddMapperConfiguration();
builder.Services.AddControllers();
builder.Services.AddSwaggerConfiguration(configuration);
builder.Services.AddRepositoryConfiguration();
builder.Services.AddServicesConfiguration();
builder.Services.AddAuthorizationConfiguration(configuration);

var app = builder.Build();

await RepositoryInitializer.InitializeRepository(app);

app.UseSerilogConfiguration();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerConfiguration();
}

app.UseHttpsRedirection();
app.UseAuthorizationConfiguration();
app.UseMiddleware(typeof(ExceptionsMiddleware));
app.MapControllers();

try
{
    Log.Information("Application starting...");
    app.Run();
}
catch (Exception ex)
{
    Log.Error("Application finished with error {error}", ex);
}
finally
{
    Log.Information("Application stopped");
    Log.CloseAndFlush();
}