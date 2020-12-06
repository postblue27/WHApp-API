using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using WHApp_API.Models;

namespace WHApp_API.Helpers
{
    public class RolesInitializer
    {
        public static async Task InitializeAsync(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            string adminUsername = "admin";
            string adminEmail = "admin@gmail.com";
            string password = "password";
            if (await roleManager.FindByNameAsync("Admin") == null)
            {
                await roleManager.CreateAsync(new Role{Name = "Admin"});
            }
            if (await roleManager.FindByNameAsync("Renter") == null)
            {
                await roleManager.CreateAsync(new Role{Name = "Renter"});
            }
            if (await roleManager.FindByNameAsync("Owner") == null)
            {
                await roleManager.CreateAsync(new Role{Name = "Owner"});
            }
            if (await roleManager.FindByNameAsync("Driver") == null)
            {
                await roleManager.CreateAsync(new Role{Name = "Driver"});
            }
            if (await userManager.FindByNameAsync(adminUsername) == null)
            {
                User admin = new User { Email = adminEmail, UserName = adminUsername };
                IdentityResult result = await userManager.CreateAsync(admin, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }
        }
    }
}