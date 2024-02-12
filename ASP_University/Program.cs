var builder = WebApplication.CreateBuilder();
builder.Services.AddSingleton<CompanyService>();
builder.Configuration
    .AddJsonFile("companies.json")
    .AddXmlFile("companies.xml")
    .AddIniFile("companies.ini")
    .AddJsonFile("userdata.json");

var app = builder.Build();

app.Map("/", (CompanyService companyService, IConfiguration configuration) =>
{
    var mostEmployeesCompany = companyService.GetCompanyWithMostEmployees();

    return $@"{mostEmployeesCompany}" + $"\n{GetUserInfo(configuration)}";
});
string GetUserInfo(IConfiguration appConfig)
{
    return ($"{appConfig["name"]} {appConfig["age"]} {appConfig["city"]}");
};

app.Run();
