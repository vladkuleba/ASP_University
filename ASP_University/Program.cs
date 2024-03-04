var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", async context =>
{
    if (File.Exists("index.html"))
    {
        await context.Response.WriteAsync(File.ReadAllText("index.html"));
    }
    else
    {
        await context.Response.WriteAsync("Index.html not found.");
    }
});

app.MapPost("/submit_form", async context =>
{
    var name = context.Request.Form["name"];
    var email = context.Request.Form["email"];
    var message = context.Request.Form["message"];

    if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(email) && !string.IsNullOrEmpty(message))
    {
        // Here you can process the form data
        await context.Response.WriteAsync("Form submitted successfully!");
    }
    else
    {
        await context.Response.WriteAsync("Please fill in all fields.");
    }
});

app.MapGet("/checkCookie", async context =>
{
    var storedValue = context.Request.Cookies["storedValue"];
    if (!string.IsNullOrEmpty(storedValue))
    {
        await context.Response.WriteAsync($"Value is: {storedValue}");
    }
    else
    {
        await context.Response.WriteAsync("No data saved.");
    }
});

app.UseMiddleware<ErrorLoggingMiddleware>();
app.Run();
