using MyNotifications.Database.Extensions;
using MyNotifications.Sender.Extensions;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddConfiguration(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddMassTransit();
builder.Services.AddDatabase(builder.Configuration);

var host = builder.Build();
await host.RunAsync();
