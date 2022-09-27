using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Business.Abstract;
using Main.Identity;
using Microsoft.AspNetCore.Identity;

namespace Main.Controllers
{
    public  class SeedIdentity
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        private ICartService _cartManager;
        public SeedIdentity(IProductService productService, ICategoryService categoryService, RoleManager<IdentityRole> roleManager, UserManager<User> userManager, ICartService cartManager)
        {
            _productService = productService;
            _categoryService = categoryService;
            _roleManager = roleManager;
            _userManager = userManager;
            _cartManager = cartManager;
        }

        IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();
        public async Task Seed()
        {
            var roles = configuration.GetSection("Data:Roles").GetChildren().Select(i=>i.Value).ToList();
            foreach (var role in roles)
            {
                if(!await _roleManager.RoleExistsAsync(role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role));
                }
            }
            var users = configuration.GetSection("Data:Users").GetChildren();
            foreach (var section in users)
            {
                var username = section.GetValue<string>("username");
                if(await _userManager.FindByNameAsync(username) == null)
                {
                    var firstname = section.GetValue<string>("firstname");
                    var lastname = section.GetValue<string>("lastname");
                    var email = section.GetValue<string>("email");
                    var password = section.GetValue<string>("password");
                    var role = section.GetValue<string>("role");
                    
                    var user = new User{
                        FirstName = firstname,
                        LastName = lastname,
                        UserName = username,
                        Email = email,
                        EmailConfirmed = true,
                    };
                    var result = await _userManager.CreateAsync(user,password);
                    if(result.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user,role);
                        _cartManager.InitializeCart(user.Id);
                    }

                }
            }
        }
    }
}
