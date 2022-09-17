using Main.Business.Abstract;
using Main.Business.Concrete;
using Main.Data.Abstract;
using Main.Data.Concrete.EfCore;
using Main.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

internal class Program
{
    private static void Main(string[] args)
    {
        var conntectionString = @"server=localhost;port=3306;user=root;password=12345;database=AspDb";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddDbContext<ApplicationContext>(options=>options.UseMySql(conntectionString,serverVersion));
        builder.Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
        // AddIdentity : Istifade edeceyim User ve Role tablolarim
        // AddEntityFrameworkStores : Istifade edeceyim DbContext : ApplicationContext
        // AddDefaultTokenProviders : şifrə sıfırlamaq üçün verilən bənzərsiz kodu yaradacaq

        // Repository
        builder.Services.AddScoped<IProductRepository,EfCoreProductRepository>();
        builder.Services.AddScoped<ICategoryRepository,EfCoreCategoryRepository>();

        //Service
        builder.Services.AddScoped<ICategoryService,CategoryManager>();
        builder.Services.AddScoped<IProductService,ProductManager>();
        // Program IProductRepository cagiranda EfCoreProductRepository-den object yaradib gonderir
        
        builder.Services.AddControllersWithViews();
        
        using var app = builder.Build();
        if(app.Environment.IsDevelopment())
        {
            SeedingDatabase.Seed();
        }


        // servisleri istifade et
        app.UseAuthentication();


        app.UseRouting();
        // app.MapGet("/", () => "Hello World!");
        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllerRoute(
                name: "adminCategoryList",
                pattern: "admin/categories",
                defaults: new{controller="Admin",action = "CategoryList"}
            );
            endpoints.MapControllerRoute(
                name: "adminCategoryCreate",
                pattern: "admin/categories/create",
                defaults: new{controller="Admin",action = "CreateCategory"}
            );
            endpoints.MapControllerRoute(
                name: "adminCategoryUpdate",
                pattern: "admin/categories/{id?}",
                defaults: new{controller="Admin",action = "UpdateCategory"}
            );



            endpoints.MapControllerRoute(
                name: "adminProductList",
                pattern: "admin/products",
                defaults: new{controller="Admin",action = "ProductList"}
            );
            endpoints.MapControllerRoute(
                name: "adminProductCreate",
                pattern: "admin/products/create",
                defaults: new{controller="Admin",action = "CreateProduct"}
            );
            endpoints.MapControllerRoute(
                name: "adminProductUpdate",
                pattern: "admin/products/{id?}",
                defaults: new{controller="Admin",action = "UpdateProduct"}
            );



            endpoints.MapControllerRoute(
                name: "products",
                pattern: "products/{category?}",
                defaults: new{controller="User",action = "List"}
            );


            endpoints.MapControllerRoute(
                name: "search",
                pattern: "search",
                defaults: new{controller="User",action = "Search"}
            );
            
            endpoints.MapControllerRoute(
                name: "productdetails",
                pattern: "{url}",
                defaults: new{controller="User",action = "Details"}
            );
            
            endpoints.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}"
            );
        });


        app.UseStaticFiles();
        app.UseStaticFiles(new StaticFileOptions
        {
            FileProvider = new PhysicalFileProvider(
                Path.Combine(builder.Environment.ContentRootPath, "node_modules")),
            RequestPath = "/modules"
        });
        app.Run();
    }
}