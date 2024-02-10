var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var iniName = "companies.ini";
var jsonName = "companies.json";
var xmlName = "companies.xml";



app.MapGet("/", async context =>
{
    var reader = new CompaniesReader();
    var companyWithMostEmployeesIni = reader.GetCompanyWithMostEmployees(iniName);
    var companyWithMostEmployeesJson = reader.GetCompanyWithMostEmployees(jsonName);
    var companyWithMostEmployeesXml = reader.GetCompanyWithMostEmployees(xmlName);

    await context.Response.WriteAsync($"Company with most employees: {companyWithMostEmployeesIni}");
});

app.Run();
