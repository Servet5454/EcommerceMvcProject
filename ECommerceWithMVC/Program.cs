using ECommerceWithMVC.Models;
using ECommerceWithMVC.Models.DataContext;
using ECommerceWithMVC.Models.Validators;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.




builder.Services.AddScoped<EntityCreater>();


//dependency injection yapmak için yaptým sonrasýnda sadece burayý kullanacaðým...
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
                   opts.ExpireTimeSpan = TimeSpan.FromDays(14);  //Burada cookie'nin ömrünü belirliyoruz...
                   opts.SlidingExpiration = false; // Burayý false vererek Kullanýcýnýn 14 gün sonra zorla tekrardan þifreyle vs login olmasýný saðlýyoruz.. true verirsek her girdiðinde süreye 14 gün ekler...
                   opts.LoginPath = "/Kullanici/GirisYap"; //Burada Kullanýcý Login Deðilse Direk Tanýmladýðýmýz controller'ýn Action'nýna gidiyor.
                                                           // opts.LogoutPath = "/Kullanici/CikisYap"; // Burayý daha tanýmlamadým tanýmlanýcak...!!!
                                                           //opts.AccessDeniedPath = "/Home/Anasayfa"; //Burasýda Yetki olmadýðý zaman gideceði yer ben burayý kullanmayý düþünmüyorum silerim ileride...
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
