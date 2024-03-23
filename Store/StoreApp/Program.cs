using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Contracts;
using Services;
using Services.Contracts;
using StoreApp.Infrastructe.Extensions;
using StoreApp.Models;


var builder = WebApplication.CreateBuilder(args);

//controller kullanýcam ve view nesnelerinden de istifade edicem demek.
builder.Services.AddControllersWithViews();

//controller olmadan da servisi kullanabilmek adýna ekliyoruz.
builder.Services.AddRazorPages();

builder.Services.ConfigureDbContext(builder.Configuration);
builder.Services.ConfigureSession();
builder.Services.ConfigureRepositoryRegistration();
builder.Services.ConfigureServiceRegistration();



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

app.ConfigureAndCheckMigration();
app.Run();

 