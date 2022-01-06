using NSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = builder.Configuration;
IWebHostEnvironment hostingEnvironment = builder.Environment;

builder.Services.AddIdentityConfiguration();

//builder.WebHost.ConfigureAppConfiguration((hostingContext, config) =>
//{
//    config.SetBasePath(hostingContext.HostingEnvironment.ContentRootPath)
//        .AddJsonFile("appsettings.json", true, true)
//        .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", true, true)
//        .AddEnvironmentVariables();
//});
builder.Configuration.SetBasePath(hostingEnvironment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings{hostingEnvironment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables();



builder.Services.AddMvcConfiguration(configuration);

builder.Services.RegisterService(configuration);

var app = builder.Build();

app.UseMvcConfiguration(builder.Environment);

app.Run();
