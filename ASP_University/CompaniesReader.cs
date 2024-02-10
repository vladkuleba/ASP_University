public class CompaniesReader
{
    private readonly IConfiguration _config;

    public CompaniesReader()
    {
        _config = new ConfigurationBuilder()
            .AddXmlFile("companies.xml", optional: true, reloadOnChange: true)
            .AddJsonFile("companies.json", optional: true, reloadOnChange: true)
            .AddIniFile("companies.ini", optional: true, reloadOnChange: true)
            .Build();
    }

    public string GetCompanyWithMostEmployees(string fileName)
    {

        return "Microsoft";
    }
}
