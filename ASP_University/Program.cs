
var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var company = new Company
{
    Name = "Example Company",
    Employees = 1000,
};

app.MapGet("/", context =>
{
    return context.Response.WriteAsync($"Company: {company.Name}, Employees: {company.Employees}");
});

app.Run();


app.MapGet("/", () => "Hello World!");

app.Run();

public class Company
{
    public string Name { get; set; }
    public int Employees { get; set; }
    public string HeadquartersLocation { get; set; }
}