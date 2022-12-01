using FamilyActivity.WebMvc.Contexts;
using FamilyActivity.WebMvc.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
builder.Services.AddScoped<ErrorHandlingMiddleware>();

//To trzeba dodac!! aby zadzialalo Configuration!!
IConfiguration Configuration;
Configuration = builder.Configuration;
//DbContext configuration

        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

        // Replace 'YourDbContext' with the name of your own DbContext derived class.
        builder.Services.AddDbContext<ApplicationContext>(
            dbContextOptions => dbContextOptions
                .UseMySql(Configuration.GetConnectionString("Default"), serverVersion)
                // The following three options help with debugging, but should
                // be changed or removed for production.
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
        );

var app = builder.Build();

//Seed database
AppDbInitializer.Seed(app);

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
