using Microsoft.EntityFrameworkCore;
using TestApp.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add database context
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add session services
builder.Services.AddDistributedMemoryCache(); // For storing session data
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout
    options.Cookie.HttpOnly = true;                // Prevent client-side script access
    options.Cookie.IsEssential = true;            // Ensure the cookie is essential
});
builder.Services.AddDbContext<MyDbContext>(options =>
    options.UseSqlServer("Server=localhost,1433;Database=ProjectDatabase7;User Id=SA;Password=Password_123;TrustServerCertificate=True")
        .LogTo(Console.WriteLine, LogLevel.Information));


builder.Logging.ClearProviders(); // Optional: Clear default providers
builder.Logging.AddConsole();
builder.Logging.AddDebug();

builder.Logging.AddFilter("Microsoft.EntityFrameworkCore.Database.Command", LogLevel.Warning);

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable session handling middleware
app.UseSession();

app.UseAuthorization();

// Set the default route to the Login action in the Account controller
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Account}/{action=Login}/{id?}");

app.Run();