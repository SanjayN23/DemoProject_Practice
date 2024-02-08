using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Pratice.Models;
using Microsoft.AspNetCore.Identity;
using Pratice.Data;
using Pratice.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PracticeDbContextConnection") ?? throw new InvalidOperationException("Connection string 'PracticeDbContextConnection' not found.");
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireUppercase = false;
});

builder.Services.AddScoped<CountryRepository>();
builder.Services .AddDbContext<TestDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<BackupCountryRepository>();
builder.Services.AddDbContext<DeletedDataDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DeletedData")));

builder.Services.AddDbContext<PracticeDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<PracticeDbContext>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
