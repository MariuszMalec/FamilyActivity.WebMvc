using FamilyActivity.WebMvc.Contexts;
using FamilyActivity.WebMvc.Middleware;
using FamilyActivity.WebMvc.Services;
using Microsoft.EntityFrameworkCore;

var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

bool sqlite = true;
if (environment.Contains("Mysql"))
    sqlite = false;//true sqlite, false mysql, add selection to environment

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
builder.Services.AddScoped<ErrorHandlingMiddleware>();
builder.Services.AddTransient<IActivityService, ActivityService>();

//To trzeba dodac!! aby zadzialalo Configuration!!
IConfiguration Configuration;
Configuration = builder.Configuration;
//DbContext configuration

if (sqlite)
{
    var connectionString = Configuration.GetConnectionString("Sqlite");
    builder.Services.AddDbContext<ApplicationContext>(o => o.UseSqlite(connectionString));
}
else
{
    var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
    builder.Services.AddDbContext<ApplicationContext>(
        dbContextOptions => dbContextOptions
            .UseMySql(Configuration.GetConnectionString("Default"), serverVersion)
            .LogTo(Console.WriteLine, LogLevel.Information)
            .EnableSensitiveDataLogging()
            .EnableDetailedErrors()
    );
}

var app = builder.Build();

//Seed database by json
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();

    if (environment == "MysqlJsonSeed")
    {
        dataContext.Database.EnsureDeleted();
        dataContext?.Database.Migrate();
        dataContext.Database.EnsureCreated();
        await SeedDataFromJson.SeedActiviesDays(dataContext);
    }
    if (environment == "MysqlClassSeed")
    {
        dataContext.Database.EnsureDeleted();
        dataContext?.Database.Migrate();
        dataContext.Database.EnsureCreated();
        await SeedData.SeedPersonFamilies(dataContext);
        await SeedData.SeedActiviesDays(dataContext);
    }
    if (environment == "sqliteCommand")
    {
        AppDbInitializerWithinSqliteCommand.CreateTableWithSqlLitePersonFamilies(app, Configuration);
        AppDbInitializerWithinSqliteCommand.SeedWithSqlLitePersonFamilies(app, Configuration);
        AppDbInitializerWithinSqliteCommand.CreateTableWithSqlLiteActivityDays(app, Configuration);
        AppDbInitializerWithinSqliteCommand.SeedWithSqliteActivityDays(app, Configuration);
    }
    if (environment == "mysqlCommand")
    {
        AppDbInitializerWithinSqliteCommand.SeedMySql(app, Configuration);
        AppDbInitializerWithinSqliteCommand.SeedMySqlData(app, Configuration);
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
