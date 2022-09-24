using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Main.Identity
{
    public  class SeedIdentity
    {
        
        public static async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
        

            var username = configuration["Data:UserAdmin:username"];
            var password = configuration["Data:UserAdmin:password"];
            var role = configuration["Data:UserAdmin:role"];
            var email = configuration["Data:UserAdmin:email"];
            if(await userManager.FindByNameAsync(username)==null)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
                var user = new User{
                    FirstName = "admin",
                    LastName = "admin",
                    UserName = username,
                    Email = email,
                    EmailConfirmed = true
                };
                var result = await userManager.CreateAsync(user,password);
                if(result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user,role);
                }
            }
        }
    }
}