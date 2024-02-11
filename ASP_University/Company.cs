public class Company
{
    public string Name { get; set; }
    public int NumberOfEmployees { get; set; }
    public static bool operator >(Company company1, Company company2)
    {
        return company1.NumberOfEmployees > company2.NumberOfEmployees;
    }
    public static bool operator <(Company company1, Company company2)
    {
        return company1.NumberOfEmployees < company2.NumberOfEmployees;
    }
}
