using Microsoft.AspNetCore.Mvc;

[Route("[controller]")]
public class LibraryController : ControllerBase
{
    private readonly IBookService _bookService;
    private readonly IProfileService _profileService;

    public LibraryController(IBookService bookService, IProfileService profileService)
    {
        _bookService = bookService;
        _profileService = profileService;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Welcome to the Library!");
    }

    [HttpGet("Books")]
    public IActionResult GetBooks()
    {
        var books = _bookService.GetBooks();
        return Ok(books);
    }

    [HttpGet("Profile/{id?}")]
    public IActionResult GetProfile(int? id)
    {
        var profileInfo = _profileService.GetProfileInfo(id);
        return Ok(profileInfo);
    }
}