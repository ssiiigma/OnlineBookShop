using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OnlineBookShop;
using OnlineBookShop.Components.Pages.Models;

var builder = WebApplication.CreateBuilder(args);

// Реєстрація сервісів
builder.Services.AddControllers();
builder.Services.AddDbContext<StoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddHttpClient("ServerAPI", client =>
{
    client.BaseAddress = new Uri("http://localhost:5000/");
});


builder.WebHost.ConfigureKestrel(options =>
{
    options.ListenLocalhost(5000); // HTTP
});



builder.Services.AddAntiforgery();

builder.Services.AddRazorPages()
    .AddRazorPagesOptions(options =>
    {
        options.RootDirectory = "/Components/Pages"; // важливо!
    });

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie();
builder.Services.AddAuthorization();

builder.Services.AddScoped<BookService>();

builder.Services.AddServerSideBlazor();

var app = builder.Build();

app.UseStaticFiles();
app.MapControllers();
app.MapRazorPages(); 
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

// scope для автоматичних міграцій
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<StoreDbContext>();
    db.Database.Migrate(); // db.Database.EnsureCreated()
}

// Маршрути для API контролерів
app.MapControllers();
app.UseDeveloperExceptionPage();

app.Run();