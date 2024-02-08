
using ASP_University;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var company = new Company
{
    Name = "Example Company",
    Employees = 1000,
    HeadquartersLocation = "Some City"
};


var random = new Random();


app.MapGet("/", context =>
{
    var randomNumber = random.Next(101);
    var randomMessage = $"Random number: {randomNumber}";
    return context.Response.WriteAsync($"Company: {company.Name}, Employees: {company.Employees}, Headquarters: {company.HeadquartersLocation}" + "\n" + randomMessage);
});

app.Run();