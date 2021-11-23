using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace leave_management.Data
{
    public static class SeedData
    {
        public static void Seed(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            SeedRoles(roleManager);
            SeedUsers(userManager);
        }
        private static void SeedRoles(RoleManager<IdentityRole> roleManager)
        {
            if (!roleManager.RoleExistsAsync("Administrator").Result)
            {
                var administratorRole = new IdentityRole
                {
                    Name = "Administrator"
                };
                var result = roleManager.CreateAsync(administratorRole).Result;
            }

            if (!roleManager.RoleExistsAsync("Employee").Result)
            {
                var employeeRole = new IdentityRole
                {
                    Name = "Employee"
                };
                var result = roleManager.CreateAsync(employeeRole).Result;
            }
        }

        private static void SeedUsers(UserManager<IdentityUser> userManager)
        {
            if (userManager.FindByNameAsync("admin").Result == null)
            {
                var adminUser = new IdentityUser
                {
                    UserName = "admin",
                    Email = "admin@localhost"
                };

                var result = userManager.CreateAsync(adminUser, "password").Result;
                if (result.Succeeded)
                {
                    userManager.AddToRoleAsync(adminUser, "Administrator").Wait();
                }
            }
        }

    }
}
