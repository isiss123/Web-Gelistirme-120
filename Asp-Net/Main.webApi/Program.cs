using Microsoft.EntityFrameworkCore;

using Main.Business.Abstract;
using Main.Business.Concrete;

using Main.Data.Abstract;
using Main.Data.Concrete.EfCore;

internal class Program
{
    private static void Main(string[] args)
    {
        string MyAllowOrigins = "_myAllowOrigins";
        IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

        var conntectionString = configuration.GetConnectionString(@"MySqlConnection");
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));

        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.
        builder.Services.AddCors(options =>
        {
            options.AddPolicy(
                name: MyAllowOrigins,
                policy  =>
                {
                    policy  .AllowAnyOrigin()
                            .AllowAnyHeader()
                            .AllowAnyMethod(); // .WithMethods("PUT", "DELETE", "GET")
                });
        });

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services.AddDbContext<MainContext>(options=>options.UseMySql(conntectionString, serverVersion));

        // Repository
        builder.Services.AddScoped<IProductRepository,EfCoreProductRepository>();
        builder.Services.AddScoped<ICategoryRepository,EfCoreCategoryRepository>();
        builder.Services.AddScoped<ICartRepository,EfCoreCartRepository>();
        builder.Services.AddScoped<IOrderRepository,EfCoreOrderRepository>();
        // builder.Services.AddScoped<IUnitOfWork,UnitOfWork>();

        //Service
        builder.Services.AddScoped<ICategoryService,CategoryManager>();
        builder.Services.AddScoped<IProductService,ProductManager>();
        builder.Services.AddScoped<ICartService,CartManager>();
        builder.Services.AddScoped<IOrderService,OrderManager>();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseCors(MyAllowOrigins);

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}