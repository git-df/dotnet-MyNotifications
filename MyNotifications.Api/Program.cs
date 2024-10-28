using FastEndpoints;
using FastEndpoints.Swagger;
using MyNotifications.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("appsettings.json", false, true);

builder.Services.AddConfiguration(builder.Configuration);
builder.Services.AddMassTransit();

builder.Services
    .AddFastEndpoints()
    .SwaggerDocument();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwaggerGen();
}

app.UseFastEndpoints();

await app.RunAsync();