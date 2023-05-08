using ECommerceWithMVC.Models.DataContext;
using ECommerceWithMVC.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Microsoft.Extensions.Options;
using ECommerceWithMVC.Models.Database_Factory;
using ECommerceWithMVC.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ECommerceWithMVC.Models.ViewModel;
using static ECommerceWithMVC.Models.EntityCreater;
using ECommerceWithMVC.Repositories;
//using NETCore.Encrypt.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;
using AspNetCore;

namespace ECommerceWithMVC.Controllers
{

    public class KullaniciController : Controller
    {
        
        /// <summary>
        /// Dependency injection dan yararlanarak controller Tarafında kullanacağım temel nesneleri constructer'a veriyorum...
        /// </summary>
        private readonly IConfiguration configuration;
        private readonly ECommerceDBContext context;
        private readonly EntityCreater creater;
        public KullaniciController(IConfiguration _configuration, ECommerceDBContext _context, EntityCreater _creater)
        {
            configuration = _configuration;
            context = _context;
            creater = _creater;
        }


        //Finished Sorunsuz Çalışmaktadır.
        public IActionResult GirisYap()
        {
            
            return View();
        }

        [HttpPost]
        public IActionResult GirisYap(KullaniciViewModel kullaniciViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["KullaniciBilgi"] = "Email Adresi yada Şifreniz Hatalı";
                return View("GirisYap", kullaniciViewModel);
            }

            else if (ModelState.IsValid)
            {
                Kullanici? kul = context?.Kullanicis?
                        .FirstOrDefault(p => p.Email == kullaniciViewModel.Email);
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, kul.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Name, kul.Ad ?? string.Empty));
                claims.Add(new Claim(ClaimTypes.Surname, kul.Soyad ?? string.Empty));

                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                ClaimsPrincipal principal = new ClaimsPrincipal(identity);

                HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                HttpContext.Session.SetString("UserEmail", kul.Email);
                HttpContext.Session.SetInt32("UserId", kul.Id);
                return RedirectToAction("Anasayfa", "Home");
            }
            else
                return RedirectToAction("Anasayfa", "Home");

        }


        [HttpPost]
        public IActionResult HesapOlustur(KullaniciViewModel kullanici)
        {

            Kullanici? EmailTelControl = context?.Kullanicis?.FirstOrDefault(k => k.Email == kullanici.Email && k.TelNo == kullanici.TelNo);

            if (kullanici.Sifre1 == kullanici.Sifre2 && EmailTelControl != null)
            {

                TempData["information"] = "Sisteme Zaten Kayıtlısınız";
                return View("GirisYap");

            }
            else
            {
                //string mD5SifreOnEk = configuration.GetValue<string>("AppSettings:MD5OnEk");
                //string paswordSifre = kullanici.Sifre1 + mD5SifreOnEk;
                //string hashedsifre1 = paswordSifre.MD5();
                //string paswordsifre2 = kullanici.Sifre2 + mD5SifreOnEk;
                //string hashedsifre2 = paswordsifre2.MD5();

                //Kullanici? DbKullanici = creater.GetInstance(EntitiesType.Kullanici) as Kullanici;
                //DbKullanici.Sifre1 = hashedsifre1;
                //DbKullanici.Sifre2 = hashedsifre2;
                //DbKullanici.Ad = kullanici.Ad;
                //DbKullanici.Soyad = kullanici.Soyad;
                //DbKullanici.Email = kullanici.Email;
                //DbKullanici.TelNo = kullanici.TelNo;

                //context?.Add(DbKullanici);
                context?.SaveChanges();

                Kullanici? kul = context?.Kullanicis?
                        .FirstOrDefault(p => p.Email == kullanici.Email);

                HttpContext.Session.SetString("UserEmail", kul.Email);
                HttpContext.Session.SetInt32("UserId", kul.Id);
                TempData["information"] = "Kayıt İşlemi Başarılı";
                return RedirectToAction("Anasayfa", "Home");

            }



        }


        //Finished Çalışmaktadır Dictionary yapıp diğer hesapları gösterme işlemi kaldı...
        public IActionResult KullaniciBilgi()
        {

            var sessionemail = HttpContext.Session.GetString("UserEmail");
            var sessionId = HttpContext.Session.GetInt32("UserId");

            Kullanici? kul = context?.Kullanicis?
            .Include(p => p.KullaniciAdress)
            .FirstOrDefault(p => p.Email == sessionemail && p.Id == sessionId);


            if (kul == null)
            {
                TempData["KullaniciBilgi"] = "Email Adresi yada Şifreniz Hatalı";
                return View("GirisYap");

            }

            if (kul != null)
            {

                TempData["Hesabım"] = ("Hesabım");

                var liste = context?.KullaniciAdress?.Where(p => p.KullaniciId == sessionId).ToList() ?? null;

                return View(liste);
            }
            else
                return RedirectToAction("GirisYap");
        }

        //Finished Sorunsuz Çalışmaktadır.
        public IActionResult AdresBilgi()
        {
            var sessionemail = HttpContext.Session.GetString("UserEmail");
            var sessionId = HttpContext.Session.GetInt32("UserId");

            Kullanici? kullanici = creater.GetInstance(EntitiesType.Kullanici) as Kullanici;
            KullaniciAdres? kullaniciAdres = creater.GetInstance(EntitiesType.KullaniciAdres) as KullaniciAdres;
            kullanici = context.Kullanicis?
                        .FirstOrDefault(p => p.Email == sessionemail);

            kullaniciAdres = context.KullaniciAdress?.FirstOrDefault(p => p.KullaniciId == sessionId);

            KullaniciVeAdresViewModel kkullaniciVeAdresViewModel = new KullaniciVeAdresViewModel  //Viewmodel olarak gönderim sağlayacağım için view model oluşturuyorum..
            {
                Id = kullanici.Id,
                Ad = kullanici?.Ad,
                Soyad = kullanici?.Soyad,
                Email = kullanici?.Email,
                TelNo = kullanici?.TelNo,
                Sifre1 = kullanici?.Sifre1,
                Sifre2 = kullanici?.Sifre2,
                KayitTarihi = kullanici?.KayitTarihi,
                Adresbasligi = kullaniciAdres?.Adresbasligi,
                Il = kullaniciAdres?.Il,
                Ilce = kullaniciAdres?.Ilce,
                Mahalle = kullaniciAdres?.Mahalle,
                AdresGenel = kullaniciAdres?.AdresGenel
            };


            return View(kkullaniciVeAdresViewModel);

        }




        //Finished Sorunsuz Çalışmaktadır. (GÜNCELLEME)
        [HttpPost]
        public IActionResult AdresBilgi(KullaniciVeAdresViewModel kullaniciVeAdresViewModel)
        {
            if (!ModelState.IsValid)
            {
                KullaniciViewModel kullaniciViewModel = new KullaniciViewModel();
                //kullaniciViewModel.Email = kullaniciVeAdresViewModel.Email;
                //kullaniciViewModel.Sifre1 =kullaniciVeAdresViewModel?.Sifre1;
                TempData["GuncellemeMessaage"] = "Eksik Bilgi Girişi Güncelleme Yapılamadı";
                return RedirectToAction("KullaniciBilgi", kullaniciVeAdresViewModel);
            }
            Kullanici? kullanici = creater.GetInstance(EntitiesType.Kullanici) as Kullanici;
            KullaniciAdres? Kadres = creater.GetInstance(EntitiesType.KullaniciAdres) as KullaniciAdres;
            var sessionemail = HttpContext.Session.GetString("UserEmail");
            var sessionId = HttpContext.Session.GetInt32("UserId");

            kullanici = context?.Kullanicis?.FirstOrDefault(p => p.Email == sessionemail);
            Kadres = context?.KullaniciAdress?.FirstOrDefault(p => p.KullaniciId == kullanici.Id);
            if (kullanici != null && Kadres != null)
            {


                kullanici.Ad = kullaniciVeAdresViewModel.Ad;
                kullanici.Soyad = kullaniciVeAdresViewModel.Soyad;
                kullanici.TelNo = kullaniciVeAdresViewModel.TelNo;
                kullanici.Sifre1 = kullaniciVeAdresViewModel.Sifre1;
                kullanici.Sifre2 = kullaniciVeAdresViewModel.Sifre2;
                Kadres.Adresbasligi = kullaniciVeAdresViewModel.Adresbasligi;
                Kadres.Il = kullaniciVeAdresViewModel.Il;
                Kadres.Ilce = kullaniciVeAdresViewModel.Ilce;
                Kadres.Mahalle = kullaniciVeAdresViewModel.Mahalle;
                Kadres.AdresGenel = kullaniciVeAdresViewModel.AdresGenel;
                context?.Kullanicis?.Update(kullanici);
                context?.KullaniciAdress?.Update(Kadres);
                TempData["information"] = "Güncelleme İşlemi Başarılı Bir Şekilde Yapıldı";
                context?.SaveChanges();


                KullaniciVeAdresViewModel kullaniciViewModel = new KullaniciVeAdresViewModel  //Viewmodel olarak gönderim sağlayacağım için view model oluşturuyorum..
                {
                    Ad = kullanici?.Ad,
                    Soyad = kullanici?.Soyad,
                    Email = kullanici?.Email,
                    TelNo = kullanici?.TelNo,
                    Sifre1 = kullanici?.Sifre1,
                    Sifre2 = kullanici?.Sifre2,
                    KayitTarihi = kullanici?.KayitTarihi,
                    Adresbasligi = Kadres?.Adresbasligi,
                    Il = Kadres?.Il,
                    Ilce = Kadres?.Ilce,
                    Mahalle = Kadres?.Mahalle,
                    AdresGenel = Kadres?.AdresGenel
                };

                return RedirectToAction("AdresBilgi", kullaniciViewModel);
            }
            else
                return View();
        }

        [HttpPost]
        public IActionResult AdresBilgiEkle(KullaniciVeAdresViewModel kullaniciVeAdresViewModel)
        {
            var sessionemail = HttpContext.Session.GetString("UserEmail");
            var sessionId = HttpContext.Session.GetInt32("UserId");
            Kullanici? kullanici = creater.GetInstance(EntitiesType.Kullanici) as Kullanici;
            KullaniciAdres? Kadres = creater.GetInstance(EntitiesType.KullaniciAdres) as KullaniciAdres;
            kullanici = context?.Kullanicis?.FirstOrDefault(p => p.Email == sessionemail);
            if (kullanici == null)
            {

                return View("AdresBilgi");
            }
            else
            {

                kullanici.KullaniciAdress = new List<KullaniciAdres>
                {
                    new KullaniciAdres
                    {
                Adresbasligi = kullaniciVeAdresViewModel.Adresbasligi,
                Il = kullaniciVeAdresViewModel.Il,
                Ilce = kullaniciVeAdresViewModel.Ilce,
                Mahalle = kullaniciVeAdresViewModel.Mahalle,
                AdresGenel = kullaniciVeAdresViewModel.AdresGenel

                    }


                };
                context.Kullanicis.Update(kullanici);
                context.SaveChanges();
            }

            TempData["information"] = "Güncelleme İşlemi Başarılı Bir Şekilde Yapıldı";
            return View("AdresBilgi", kullaniciVeAdresViewModel);
        }

        //Finished Sorunsuz Çalışmakdadır...
        public IActionResult HesapOlustur()
        {

            return View();
        }



    }
}
