using NSE.WebApp.MVC.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityConfiguration();

builder.Services.AddMvcConfiguration();

builder.Services.RegisterService();

var app = builder.Build();

app.UseMvcConfiguration(builder.Environment);

app.Run();
