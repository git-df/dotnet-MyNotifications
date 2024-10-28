using MyNotifications.DiscordSender.Extensions;

var builder = Host.CreateApplicationBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", false, true);

builder.Services.AddConfiguration(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddMassTransit();

var host = builder.Build();
await host.RunAsync();
