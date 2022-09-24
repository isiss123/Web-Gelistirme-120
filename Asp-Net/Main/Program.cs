using Main.Business.Abstract;
using Main.Business.Concrete;
using Main.Data.Abstract;
using Main.Data.Concrete.EfCore;
using Main.EmailService;
using Main.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
internal class Program
{

    private static void Main(string[] args)
    {
        IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

        var conntectionString = @"server=localhost;port=3306;user=root;password=12345;database=AspDb";
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

        var builder = WebApplication.CreateBuilder(args);
        
        builder.Services.AddDbContext<ApplicationContext>(options=>options.UseMySql(conntectionString,serverVersion));
        builder.Services.AddIdentity<User,IdentityRole>().AddEntityFrameworkStores<ApplicationContext>().AddDefaultTokenProviders();
        // AddIdentity : Istifade edeceyim User ve Role tablolarim
        // AddEntityFrameworkStores : Istifade edeceyim DbContext : ApplicationContext
        // AddDefaultTokenProviders : şifrə sıfırlamaq üçün verilən bənzərsiz kodu yaradacaq
        builder.Services.Configure<IdentityOptions>(options=> {
            // password
                options.Password.RequireDigit = true; // Mutleq icerisinde reqem olmalidir
                options.Password.RequireLowercase = true; // Mutleq icerisinde balaca herf olmalidir
                options.Password.RequireUppercase = true; // Mutleq icerisinde boyuk herf olmalidir
                options.Password.RequireNonAlphanumeric = true; // icerisinde herfler, reqemler ve isareler olmalidir

            // lockout : hesap kilidleme
                options.Lockout.MaxFailedAccessAttempts = 5; // 5 yanlis sifre girisinden sonra hesab kilidlenir
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); // 5 deqiqe sonra istifadeci hesabina tekrar gire biler
                options.Lockout.AllowedForNewUsers = true; // hesap kilidlemeyi aktiv etmek ucun
            // user 
                // options.User.AllowedUserNameCharacters = "qwertyuiopasdfghjklzxcvbnm1234567890_."; // istifadeci adinda icaze verilen karakterler
                options.User.RequireUniqueEmail = true; // her bir istifadecinin ferqli email adresi olmalidir
            // signin
                options.SignIn.RequireConfirmedEmail = true; // yeni hesap acarken email dogruladiqdan sonra hesab aktiv olur
                options.SignIn.RequireConfirmedPhoneNumber = false; // yeni hesap acarken nomreni dogruladiqdan sonra hesab aktiv olur

        });
        builder.Services.ConfigureApplicationCookie( options=>{
            options.LoginPath = "/account/login";
            options.LogoutPath = "/account/logout";
            options.AccessDeniedPath = "/account/accessdenied"; // yetkisi olmayan yere daxil olanda gedeceyi link
            options.SlidingExpiration = true; // herdefe istek gonderende vaxt sifirlanir
            options.ExpireTimeSpan = TimeSpan.FromDays(1); // 1 gun sonra tarayicida olan cookies silinir
            options.Cookie = new CookieBuilder{
                HttpOnly = true, // yalniz http isteklerini qebul edir
                Name = ".AxotApp.Security.Cookie",
                SameSite = SameSiteMode.Strict // cookie-nin basqa biri terefinden istifade edilmesinin qarsini alir
            };
        });

        // Repository
        builder.Services.AddScoped<IProductRepository,EfCoreProductRepository>();
        builder.Services.AddScoped<ICategoryRepository,EfCoreCategoryRepository>();
        builder.Services.AddScoped<ICartRepository,EfCoreCartRepository>();

        //Service
        builder.Services.AddScoped<ICategoryService,CategoryManager>();
        builder.Services.AddScoped<IProductService,ProductManager>();
        builder.Services.AddScoped<ICartService,CartManager>();
        // Program IProductRepository cagiranda EfCoreProductRepository-den object yaradib gonderir

        builder.Services.AddScoped<IEmailSender,SmtpEmailSender>(i=>
            new SmtpEmailSender(
                configuration["EmailSender:Host"],
                configuration.GetValue<int>("EmailSender:Port"),
                configuration.GetValue<bool>("EmailSender:EnableSSl"),
                configuration["EmailSender:UserName"],
                configuration["EmailSender:Password"]

            )
        );
        
        
        builder.Services.AddControllersWithViews();
        
        using var app = builder.Build();
        if(app.Environment.IsDevelopment())
        {
            SeedingDatabase.Seed();
        }


        // servisleri istifade et
        app.UseAuthentication();


        app.UseRouting();
        app.UseAuthorization();

        // app.MapGet("/", () => "Hello World!");
        app.UseEndpoints(endpoints =>
        {
            // CART
            endpoints.MapControllerRoute(
                name: "CartIndex",
                pattern: "cart",
                defaults: new{controller="Cart",action = "Index"}
            );
            endpoints.MapControllerRoute(
                name: "CartCheckout",
                pattern: "checkout",
                defaults: new{controller="Cart",action = "Checkout"}
            );



            
            // admin USER
            endpoints.MapControllerRoute(
                name: "adminUserList",
                pattern: "admin/users",
                defaults: new{controller="Admin",action = "UserList"}
            );
            endpoints.MapControllerRoute(
                name: "adminUserCreate",
                pattern: "admin/user/create",
                defaults: new{controller="Admin",action = "CreateUser"}
            );
            endpoints.MapControllerRoute(
                name: "adminUserUpdate",
                pattern: "admin/user/{id?}",
                defaults: new{controller="Admin",action = "UpdateUser"}
            );



            // admin ROLE
            endpoints.MapControllerRoute(
                name: "adminRoleList",
                pattern: "admin/roles",
                defaults: new{controller="Admin",action = "RoleList"}
            );
            endpoints.MapControllerRoute(
                name: "adminRoleCreate",
                pattern: "admin/role/create",
                defaults: new{controller="Admin",action = "CreateRole"}
            );
            endpoints.MapControllerRoute(
                name: "adminRoleUpdate",
                pattern: "admin/role/{id?}",
                defaults: new{controller="Admin",action = "UpdateRole"}
            );



            // admin CATEGORY
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


            // admin PRODUCT
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

        // await SeedIdentity.Seed(configuration);
        app.Run();
        
    }
}