using AuthPracCore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MISAudit.Models
{
    public class Seeder
    {
        public async static Task SeedUsers(IServiceProvider services)
        {

            var _context = services.GetRequiredService<AppDbContext>();
            var _roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
            var _userManager = services.GetRequiredService<UserManager<ApplicationUser>>();


            //Admin
            var admin = new ApplicationUser
            {
                
                PhoneNumber = "+098765433",
                UserName = "admin@gmail.com",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                LockoutEnabled = false,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            if (!_context.Roles.Any(r => r.Name == RoleName.Admin))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = RoleName.Admin });
            }

            if (!_context.Users.Any(u => u.UserName == admin.UserName))
            {
                await _userManager.CreateAsync(admin, "Admin@123");
                await _userManager.AddToRoleAsync(admin, RoleName.Admin);
            }
            await _context.SaveChangesAsync();
        }

    }
}
