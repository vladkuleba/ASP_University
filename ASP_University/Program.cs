var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .AddJsonFile("companies.json")
    .AddXmlFile("companies.xml")
    .AddIniFile("companies.ini");

var app = builder.Build();

app.MapGet("/", async context =>
{


    await context.Response.WriteAsync("Hello");
});

app.Run();