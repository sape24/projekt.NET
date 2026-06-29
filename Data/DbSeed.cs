using Microsoft.AspNetCore.Identity;
namespace projekt.NET.Data;

public static class DbSeed
{
    public static async Task SeedAdminAsync (IServiceProvider services, IConfiguration config)
    {
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        var userManager = services.GetRequiredService<UserManager<IdentityUser>>();

        if (!await roleManager.RoleExistsAsync("Admin"))
        {
            await roleManager.CreateAsync(new IdentityRole("Admin"));
        }

        var email = config["AdminUser:Email"];
        var password = config["AdminUser:Password"];

        if (email == null || password == null) return;

        if (await userManager.FindByEmailAsync(email) == null)
        {
            var admin = new IdentityUser
            {
                UserName = email,
                Email = email,
                EmailConfirmed = true
            };

            var result = await userManager.CreateAsync(admin, password);
            if(result.Succeeded)
            {
                await userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
}