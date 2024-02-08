public class CompanyConfigService
{
    private readonly IConfiguration _config;

    public CompanyConfigService(IConfiguration config)
    {
        _config = config;
    }

    public string GetCompanyWithMostEmployees()
    {
        int maxEmployees = 0;
        string maxCompanyName = "";

        foreach (var companyConfig in _config.GetSection("Companies").GetChildren())
        {
            var employees = companyConfig.GetValue<int>("Employees");
            if (employees > maxEmployees)
            {
                maxEmployees = employees;
                maxCompanyName = companyConfig.GetValue<string>("Name");
            }
        }

        return maxCompanyName;
    }
}
