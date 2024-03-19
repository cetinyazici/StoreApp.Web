using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Models;


var builder = WebApplication.CreateBuilder(args);

//controller kullanýcam ve view nesnelerinden de istifade edicem demek.
builder.Services.AddControllersWithViews();

//controller olmadan da servisi kullanabilmek adýna ekliyoruz.
builder.Services.AddRazorPages();

builder.Services.AddDbContext<RepositoryContext>(options =>
{
    options.UseSqlite(builder.Configuration.GetConnectionString("sqlconnection"),
        b => b.MigrationsAssembly("StoreApp"));
});

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.Cookie.Name = "StoreAppSession";
    //10 dakka verileri tut sonra oturumu düþür.
    options.IdleTimeout = TimeSpan.FromMinutes(10);
});
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IRepositoryManager, RepositoryManager>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

builder.Services.AddScoped<Services.Contracts.Cart, ServiceManager>();
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

builder.Services.AddScoped(c => SessionCart.GetCart(c));

builder.Services.AddAutoMapper(typeof(Program));

var app = builder.Build();

app.UseSession();
app.UseStaticFiles();
app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoinds =>
{
    endpoinds.MapAreaControllerRoute(
        name: "Admin",
        areaName: "Admin",
        pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}"
        );
    endpoinds.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
    endpoinds.MapRazorPages();
});



app.Run();

