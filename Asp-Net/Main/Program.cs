using Main.Business.Abstract;
using Main.Business.Concrete;
using Main.Data.Abstract;
using Main.Data.Concrete.EfCore;
using Microsoft.Extensions.FileProviders;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

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
        app.UseRouting();
        // app.MapGet("/", () => "Hello World!");
        app.UseEndpoints(endpoints =>
        {
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
            RequestPath = "/node_modules"
        });
        app.Run();
    }
}