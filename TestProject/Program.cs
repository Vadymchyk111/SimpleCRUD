using TestProject.Domain.Store;
using TestProject.Infrastructure;
using TestProject.Infrastructure.Repositories.Store;
using TestProject.Services.Store;
using TestProject.Settings;

var builder = WebApplication.CreateBuilder(args);
AppSettings appSettings = new AppSettings();
builder.Configuration.Bind(nameof(AppSettings), appSettings);
builder.Services.AddControllers();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
//Dependency
builder.Services.AddSingleton<AppSettings>(appSettings);
builder.Services.AddTransient<DatabaseContext>(_ => new DatabaseContext(appSettings.DatabaseSettings.ConnectionString));
builder.Services.AddTransient<IBookService, BookService>();
builder.Services.AddTransient<IBookRepository, BookRepository>();

var app = builder.Build();
app.MapControllers();
DatabaseContext context = app.Services.GetRequiredService<DatabaseContext>();
await context.InitializeDatabaseAsync(appSettings.DatabaseSettings.ConnectionString);

app.Run();