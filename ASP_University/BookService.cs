public interface IBookService
{
    List<string> GetBooks();
}

public class BookService : IBookService
{
    private readonly IConfiguration _configuration;

    public BookService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public List<string> GetBooks()
    {
        return _configuration.GetSection("Books").Get<List<string>>();
    }
}