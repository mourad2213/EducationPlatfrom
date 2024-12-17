using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<MilestoneContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddDefaultIdentity<UserAcccount>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<MilestoneContext>();

// Configure authentication paths to use custom pages
builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/AccountController1/Login";
    options.AccessDeniedPath = "/AccountController1/AccessDenied";
});

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

var app = builder.Build();

// Seed roles if they don't exist
await SeedRolesAsync(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();

// Seed roles on application startup
static async Task SeedRolesAsync(WebApplication app)
{
    var roleManager = app.Services.GetRequiredService<RoleManager<IdentityRole>>();
    string[] roleNames = { "Admin", "Instructor", "Learner" };

    foreach (var roleName in roleNames)
    {
        var roleExist = await roleManager.RoleExistsAsync(roleName);
        if (!roleExist)
        {
            await roleManager.CreateAsync(new IdentityRole(roleName));
        }
    }
}
