using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Business.Abstract;
using Main.Business.Concrete;
using Main.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;


namespace Main.Identity
{
    public  class SeedIdentity
    {
        
        public static async Task Seed(UserManager<User> userManager, RoleManager<IdentityRole> roleManager,ICartService cartService,IConfiguration configuration)
        {

            var roles = configuration.GetSection("Data:Roles").GetChildren().Select(x=>x.Value).ToArray();

            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            var users = configuration.GetSection("Data:Users");

            foreach (var section in users.GetChildren())
            {
                var username = section.GetValue<string>("username");
                var password = section.GetValue<string>("password");
                var email = section.GetValue<string>("email");
                var role = section.GetValue<string>("role");
                var firstName = section.GetValue<string>("firstName");
                var lastName = section.GetValue<string>("lastName");

                if(await userManager.FindByNameAsync(username)==null)
                {
                    var user = new User()
                    {
                        UserName = username,
                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        EmailConfirmed = true
                    };

                    var result = await userManager.CreateAsync(user,password);
                    if(result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user,role);
                        cartService.InitializeCart(user.Id);
                    }
                }
            }
        }
    }

    public static class Seed
    {
        public static async Task Initialize(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            using(RoleManager<IdentityRole> roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>())
            {
                var roles = configuration.GetSection("Data:Roles").GetChildren().Select(x=>x.Value).ToArray();
                foreach (var role in roles)
                {
                    if(!roleManager.Roles.Any(i=>i.Name == role))
                    {
                        await roleManager.CreateAsync(new IdentityRole(role));
                    }
                }
                
            }
            await AddUser(serviceProvider,configuration);
        }
        public static async Task AddUser(IServiceProvider serviceProvider, IConfiguration configuration)
        {
            using(UserManager<User> userManager = serviceProvider.GetRequiredService<UserManager<User>>())
            {

            
                var users = configuration.GetSection("Data:Users");

                foreach (var section in users.GetChildren())
                {
                    var username = section.GetValue<string>("username");
                    var password = section.GetValue<string>("password");
                    var email = section.GetValue<string>("email");
                    var role = section.GetValue<string>("role");
                    var firstName = section.GetValue<string>("firstName");
                    var lastName = section.GetValue<string>("lastName");

                    if(!userManager.Users.Any(i=>i.UserName==username))
                    {
                        var user = new User{
                            UserName = username,
                            Email = email,
                            FirstName = firstName,
                            LastName = lastName,
                            EmailConfirmed = true
                        };
                        var result = await userManager.CreateAsync(user,password);
                        if(result.Succeeded)
                        {
                            await userManager.AddToRoleAsync(user,role);
                            using( var connection = getMySqlConnection(configuration))
                            {
                                connection.Open();
                                string cmd = "INSERT INTO carts ( UserId ) VALUES (@userid)";
                                var sql = new MySqlCommand(cmd,connection);
                                sql.Parameters.AddWithValue("@userid",user.Id);
                                sql.ExecuteNonQuery();
                            }
                        }
                    }
                }
            }
        }
    
        private static MySqlConnection getMySqlConnection(IConfiguration configuration)
        {
            string connectionString = configuration[@"ConnectionStrings:MySqlConnection"];
            return new MySqlConnection(connectionString);
        }
    }
}