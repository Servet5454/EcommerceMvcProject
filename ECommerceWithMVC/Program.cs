using ECommerceWithMVC.Models;
using ECommerceWithMVC.Models.DataContext;
using ECommerceWithMVC.Models.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.AddScoped<EntityCreater>();


//dependency injection yapmak i�in yapt�m sonras�nda sadece buray� kullanaca��m...
builder.Services.AddDbContext<ECommerceDBContext>(opts =>
{
    opts.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddSession();
builder.Services
               .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(opts =>
               {
                   opts.Cookie.Name = ".ECommerceWithMVC";
                   opts.ExpireTimeSpan = TimeSpan.FromDays(14);  //Burada cookie'nin �mr�n� belirliyoruz...
                   opts.SlidingExpiration = false; // Buray� false vererek Kullan�c�n�n 14 g�n sonra zorla tekrardan �ifreyle vs login olmas�n� sa�l�yoruz.. true verirsek her girdi�inde s�reye 14 g�n ekler...
                   opts.LoginPath = "/Kullanici/GirisYap"; //Burada Kullan�c� Login De�ilse Direk Tan�mlad���m�z controller'�n Action'n�na gidiyor.
                                                           // opts.LogoutPath = "/Kullanici/CikisYap"; // Buray� daha tan�mlamad�m tan�mlan�cak...!!!
                                                           //opts.AccessDeniedPath = "/Home/Anasayfa"; //Buras�da Yetki olmad��� zaman gidece�i yer ben buray� kullanmay� d���nm�yorum silerim ileride...
               });

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
    pattern: "{controller=Home}/{action=Anasayfa}/{id?}");
app.UseSession();
app.Run();
