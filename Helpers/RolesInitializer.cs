using System.Collections.Generic;
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
            var roles = new List<Role>
            {
                new Role{Name = "Admin"},
                new Role{Name = "Owner"},
                new Role{Name = "Renter"},
                new Role{Name = "Driver"},
            };

            foreach (var role in roles)
            {
                if (await roleManager.FindByNameAsync(role.Name) == null)
                {
                    await roleManager.CreateAsync(role);
                }
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