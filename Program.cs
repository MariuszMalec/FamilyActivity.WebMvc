using FamilyActivity.WebMvc.Contexts;
using FamilyActivity.WebMvc.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddHttpClient();
builder.Services.AddScoped<ErrorHandlingMiddleware>();

//to musi byc dla core6
ConfigurationManager configuration = builder.Configuration;
IWebHostEnvironment environment = builder.Environment;
var connectionString = configuration.GetConnectionString("Default");
builder.Services.AddDbContext<ApplicationContext>(o => o.UseNpgsql(connectionString));
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
