public interface IProfileService
{
    string GetProfileInfo(int? id);
}

public class ProfileService : IProfileService
{
    private readonly IConfiguration _configuration;

    public ProfileService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string GetProfileInfo(int? id)
    {
        if (id.HasValue && id >= 0 && id <= 5)
        {
            return _configuration.GetSection($"Profiles:{id}").Get<string>();
        }

        return _configuration.GetSection("CurrentUser").Get<string>();
    }
}