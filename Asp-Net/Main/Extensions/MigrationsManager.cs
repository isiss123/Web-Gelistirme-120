using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Main.Data.Concrete.EfCore;
using Main.Identity;
using Microsoft.EntityFrameworkCore;

namespace Main.Extensions
{
    public static class MigrationsManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using(var scope = host.Services.CreateScope())
            {
                using( var applicationContext = scope.ServiceProvider.GetRequiredService<ApplicationContext>())
                {
                    try
                    {
                        applicationContext.Database.Migrate();
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                }
                using( var mainContext = scope.ServiceProvider.GetRequiredService<MainContext>())
                {
                    try
                    {
                        mainContext.Database.Migrate();
                    }
                    catch (System.Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw;
                    }
                }
            }
            return host;
        }
    }
}