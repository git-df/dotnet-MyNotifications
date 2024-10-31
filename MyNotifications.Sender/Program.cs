using MyNotifications.Sender.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddConfiguration(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddMassTransit();

var host = builder.Build();
await host.RunAsync();
