var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("data.json", optional: true, reloadOnChange: true);

builder.Services.AddControllers();
builder.Services.AddSingleton<IBookService, BookService>();
builder.Services.AddSingleton<IProfileService, ProfileService>();

var app = builder.Build();

app.MapControllers();

app.Run();