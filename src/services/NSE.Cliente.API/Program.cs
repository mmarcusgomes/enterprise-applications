using NSE.Clientes.API.Configuration;
using NSE.WebAPI.Core.Identidade;


// Add services to the container.

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;

// Add services to the container.


builder.Services.AddControllers();

builder.WebHost.ConfigureAppConfiguration((hostingContext, config) =>
{
    config.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
        .AddJsonFile("appsettings.json", true, true)
        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
        .AddEnvironmentVariables();
});

builder.Services.AddApiConfiguration(configuration);

builder.Services.AddJwtConfiguration(configuration);

builder.Services.AddSwaggerConfiguration();

builder.Services.RegisterServices();

var app = builder.Build();

app.UseSwaggerConfiguration();

app.UseApiConfiguration(builder.Environment);

app.MapControllers();

app.Run();
