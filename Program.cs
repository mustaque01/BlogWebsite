using Microsoft.EntityFrameworkCore;
using BlogWebsite.Data;
using BlogWebsite.Models;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Database + Identity setup
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
    ?? "Data Source=blog.db"; // fallback to SQLite file

// Choose provider based on connection string pattern
if (connectionString.Contains(".db"))
{
    builder.Services.AddDbContext<BlogWebsite.Data.ApplicationDbContext>(options =>
        options.UseSqlite(connectionString));
}
else
{
    builder.Services.AddDbContext<BlogWebsite.Data.ApplicationDbContext>(options =>
        options.UseSqlServer(connectionString));
}

builder.Services.AddIdentity<BlogWebsite.Models.ApplicationUser, Microsoft.AspNetCore.Identity.IdentityRole>()
    .AddEntityFrameworkStores<BlogWebsite.Data.ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

// TODO: Run EF Core migrations to create the database:
// dotnet ef migrations add InitialCreate
// dotnet ef database update

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();
app.MapRazorPages();

// Seed sample data
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ApplicationDbContext>();
    var userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
    await BlogWebsite.Data.SeedData.Initialize(services, context, userManager);
}

app.Run();
