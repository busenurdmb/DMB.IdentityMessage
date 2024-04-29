using DMB.IdentityMessage.BusinessLayer;
using DMB.IdentityMessage.BusinessLayer.Abstract;
using DMB.IdentityMessage.BusinessLayer.Concrete;
using DMB.IdentityMessage.DataAccessLayer.Abstract;
using DMB.IdentityMessage.DataAccessLayer.Context;
using DMB.IdentityMessage.DataAccessLayer.EfEntityFramework;
using DMB.IdentityMessage.EntityLayer.Entities;
using DMB.IdentityMessage.PresentationLayer.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddBusinessServices();
builder.Services.AddIdentity<AppUser, AppRole>().AddEntityFrameworkStores<DMBContext>().AddErrorDescriber<CustomIdentityValidator>(); 
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
//builder.Services.Configure<IdentityOptions>(config =>
//{
//    config.Password.RequiredLength = 5; //En az ka� karakterli olmas� gerekti�ini belirtiyoruz.
//    config.Password.RequireNonAlphanumeric = false; //Alfanumerik zorunlulu�unu kald�r�yoruz.
//    config.Password.RequireDigit = false;//0-9 aras� say�sal karakter zorunlulu�unu kald�r�yoruz.
//    config.Password.RequireLowercase = false;//K���k harf zorunlulu�unu kald�r�yoruz.
//    config.Password.RequireUppercase = false; //B�y�k harf zorunlulu�unu kald�r�yoruz.
//    config.User.RequireUniqueEmail = false;//Email adreslerini tekille�tiriyoruz.
//    config.User.AllowedUserNameCharacters = "abc�defghi�jklmno�pqrs�tu�vwxyzABC�DEFGHI�JKLMNO�PQRS�TU�VWXYZ0123456789-._@+"; //Kullan�c� ad�nda ge�erli olan karakterleri belirtiyoruz.

//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
