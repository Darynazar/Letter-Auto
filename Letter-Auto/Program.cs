using Letter_Auto.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();


//using Letter_Auto.Data;
//using Microsoft.AspNetCore.Identity;
//using Microsoft.EntityFrameworkCore;
//
//var builder = WebApplication.CreateBuilder(args);
//
//// Add services to the container.
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
//                       ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(connectionString));
//builder.Services.AddDatabaseDeveloperPageExceptionFilter();
//
//// Configure Identity to support roles
//builder.Services.AddIdentity<IdentityUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = false)
//    .AddEntityFrameworkStores<ApplicationDbContext>()
//    .AddDefaultTokenProviders();  // Add role support here
//
//builder.Services.AddControllersWithViews();
//
//var app = builder.Build();
//
//// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseMigrationsEndPoint();
//}
//else
//{
//    app.UseExceptionHandler("/Home/Error");
//    app.UseHsts();
//}
//
//app.UseHttpsRedirection();
//app.UseStaticFiles();
//
//app.UseRouting();
//
//app.UseAuthentication();  // Add this line for user authentication
//app.UseAuthorization();
//
//// Define routes
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");
//app.MapRazorPages();
//
//// Seed Roles and Users
//using (var scope = app.Services.CreateScope())
//{
//    var services = scope.ServiceProvider;
//    await RoleSeeder.SeedRolesAndUsersAsync(services);  // Call the seeding method
//}
//
//app.Run();
//
//// Add RoleSeeder Class
//static public class RoleSeeder
//{
//    public static async Task SeedRolesAndUsersAsync(IServiceProvider serviceProvider)
//    {
//        var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
//        var userManager = serviceProvider.GetRequiredService<UserManager<IdentityUser>>();
//
//        // Define roles
//        string[] roleNames = { "Admin", "User", "Manager" };
//        IdentityResult roleResult;
//
//        // Create roles if they do not exist
//        foreach (var roleName in roleNames)
//        {
//            var roleExists = await roleManager.RoleExistsAsync(roleName);
//            if (!roleExists)
//            {
//                roleResult = await roleManager.CreateAsync(new IdentityRole(roleName));
//            }
//        }
//
//        // Seed admin user
//        IdentityUser adminUser = await userManager.FindByEmailAsync("admin@example.com");
//        if (adminUser == null)
//        {
//            adminUser = new IdentityUser()
//            {
//                UserName = "admin@example.com",
//                Email = "admin@example.com",
//                EmailConfirmed = true
//            };
//
//            await userManager.CreateAsync(adminUser, "AdminPassword123!");
//            await userManager.AddToRoleAsync(adminUser, "Admin");
//        }
//    }
//}
