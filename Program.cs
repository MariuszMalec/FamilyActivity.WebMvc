using FamilyActivity.WebMvc.Contexts;
using FamilyActivity.WebMvc.Enums;
using FamilyActivity.WebMvc.Middleware;
using FamilyActivity.WebMvc.Models;
using FamilyActivity.WebMvc.Services;
using Microsoft.EntityFrameworkCore;

//podczas tworzenia migracji nie jest czytana zmiennna environment, trzeba w package console przed
//migracja wpisac $env:ASPNETCORE_ENVIRONMENT='MysqlClassSeed'
var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

//aby migracja mysql zadzialala nie dziala env w vsc lub na linuxie! Patrz komentarz wyzej
bool sqlite = true;

if (environment.Contains("Mysql") && environment.Contains("Postgres"))
    sqlite = false;//true sqlite, false mysql, add selection to environment

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

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


    builder.Services.AddDbContext<WorkOrderDbContext>(options => options
        .UseSqlite(builder.Configuration.GetConnectionString("WorkOrderContext")));
}
else
{
    //var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
    //builder.Services.AddDbContext<ApplicationContext>(
    //    dbContextOptions => dbContextOptions
    //        .UseMySql(Configuration.GetConnectionString("Default"), serverVersion)
    //        .LogTo(Console.WriteLine, LogLevel.Information)
    //        .EnableSensitiveDataLogging()
    //        .EnableDetailedErrors()
    //);

    if (environment.Contains("Mysql"))
    {
        var conectionString = Configuration.GetConnectionString("Default");
        builder.Services.AddDbContext<ApplicationContext>(o => o.UseMySql(conectionString, ServerVersion.AutoDetect(conectionString)));
        builder.Services.AddDbContext<ApplicationContext>();

        var conectionString2 = Configuration.GetConnectionString("WorkOrderContextMySql");
        //builder.Services.AddDbContext<MaintenanceDbContext>(o => o.UseLazyLoadingProxies().UseMySql(conectionString, ServerVersion.AutoDetect(conectionString)));
        builder.Services.AddDbContext<WorkOrderDbContext>(o => o.UseMySql(conectionString2, ServerVersion.AutoDetect(conectionString2)));
        builder.Services.AddDbContext<WorkOrderDbContext>();
    }
    if (environment.Contains("Postgres"))
    {
        var conectionString = Configuration.GetConnectionString("WinPgActivity");
        builder.Services.AddDbContext<ApplicationContext>(o => o.UseNpgsql(conectionString));
        builder.Services.AddDbContext<ApplicationContext>();

        var conectionString2 = Configuration.GetConnectionString("WinPgWorkOrder");
        builder.Services.AddDbContext<WorkOrderDbContext>(o => o.UseNpgsql(conectionString2));
        builder.Services.AddDbContext<WorkOrderDbContext>();
    }
}

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);//TODO dodane aby poprawic blad zapisu czasu utc w postgres

var app = builder.Build();

//Seed database by json
using (var scope = app.Services.CreateScope())
{
    var dataContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    var dayPilotContext = scope.ServiceProvider.GetRequiredService<WorkOrderDbContext>();

    if (environment == EnumProvider.MysqlJsonSeed.ToString())
    {
        dataContext.Database.EnsureDeleted();
        dataContext?.Database.Migrate();
        dataContext.Database.EnsureCreated();
        await SeedDataFromJson.SeedPersonFamilies(dataContext);
        await SeedDataFromJson.SeedActivityPictures(dataContext);
        await SeedDataFromJson.SeedActiviesDays(dataContext);
    }
    if (environment == EnumProvider.MysqlClassSeed.ToString() || environment == EnumProvider.WinPostgres.ToString())
    {
        dataContext.Database.EnsureDeleted();
        dataContext?.Database.Migrate();
        dataContext.Database.EnsureCreated();
        await SeedData.SeedPersonFamilies(dataContext);
        await SeedData.SeedPictureActivities(dataContext);
        await SeedData.SeedActiviesDays(dataContext);

        //dayPilotContext.Database.EnsureDeleted();
        //dayPilotContext?.Database.Migrate();
        dayPilotContext.Database.EnsureCreated();
        await SeedActivityOrder.SeedActiviesOrders(dayPilotContext, dataContext);
    }
    if (environment == EnumProvider.sqliteCommand.ToString())
    {
        //dataContext.Database.EnsureDeleted();
        dataContext.Database.EnsureCreated();
        //AppDbInitializerWithinSqliteCommand.CreateTableWithSqlLitePersonFamilies(app, Configuration);
        AppDbInitializerWithinSqliteCommand.SeedWithSqlLitePersonFamilies(app, Configuration);
        AppDbInitializerWithinSqliteCommand.SeedWithSqlLiteAvtivityPictures(app, Configuration);
        //AppDbInitializerWithinSqliteCommand.CreateTableWithSqlLiteActivityDays(app, Configuration);
        AppDbInitializerWithinSqliteCommand.SeedWithSqliteActivityDays(app, Configuration);

        //dayPilotContext.Database.EnsureDeleted();
        dayPilotContext.Database.EnsureCreated();
        //await SeedActivityOrder.SeedActiviesOrders(dayPilotContext, dataContext);
    }
    if (environment == EnumProvider.MysqlCommand.ToString())
    {
        dataContext.Database.EnsureDeleted();
        dataContext.Database.EnsureCreated();
        //AppDbInitializerWithinMySqlCommand.CreateTableWithMySqlPersonFamilies(app, Configuration);
        AppDbInitializerWithinMySqlCommand.SeedWithMySqlPersonFamilies(app, Configuration);

        //AppDbInitializerWithinMySqlCommand.CreateTableWithMySqlAvtivityPictures(app, Configuration);
        AppDbInitializerWithinMySqlCommand.SeedWithMySqlAvtivityPictures(app, Configuration);

        //AppDbInitializerWithinMySqlCommand.CreateTableWithMySqlActivityDays(app, Configuration);
        AppDbInitializerWithinMySqlCommand.SeedWithMySqlActivityDays(app, Configuration);
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

//app.MapRazorPages();
//app.MapControllers();

app.Run();
