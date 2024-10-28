using FastEndpoints;
using FastEndpoints.Swagger;
using MyNotifications.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddConfiguration(builder.Configuration);
builder.Services.AddMassTransit();

builder.Services
    .AddFastEndpoints()
    .SwaggerDocument();

var app = builder.Build();

app.UseFastEndpoints()
    .UseSwaggerGen();

await app.RunAsync();