using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace SportStore.Models
{
    public class SeedUsers
    {
        public static async Task Seed(UserManager<IdentityUser> userManager)
        {
            IdentityUser user = await userManager.FindByIdAsync("admin@admin.pl");
            if (user == null)
            {
                user = new IdentityUser("admin@admin.pl");
                await userManager.CreateAsync(user, "Wsei123!");
            }
        }
    }
}
