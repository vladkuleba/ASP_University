using ASP_University;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

var config = new ConfigurationBuilder()
    .AddXmlFile("companies.xml", optional: true, reloadOnChange: true)
    .AddJsonFile("companies.json", optional: true, reloadOnChange: true)
    .AddIniFile("companies.ini", optional: true, reloadOnChange: true)
    .Build();

// ????????????? IConfiguration ?? ??????
app.Services.AddSingleton<IConfiguration>(config);

// ????????? ??????? CompanyConfigService ?? ?????????? ???????????
app.Services.AddSingleton<CompanyConfigService>();

app.MapGet("/", async context =>
{
    var companyService = context.RequestServices.GetRequiredService<CompanyConfigService>();
    var companyWithMostEmployees = companyService.GetCompanyWithMostEmployees();

    await context.Response.WriteAsync($"Company with the most employees: {companyWithMostEmployees}");
});

app.Run();
