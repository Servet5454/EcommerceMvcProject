using ECommerceWithMVC.Models.Entities;
using ECommerceWithMVC.Models.Model;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace ECommerceWithMVC.Models.DataContext
{
    //Burada database ile nasıl ilişki kuracağımızı belirteceğiz hangi entitylerimiz hangi table'ı oluşturacak vs onları ayarlıyacağız..
    public class ECommerceDBContext : DbContext
    {
       


        public DbSet<Kullanici>? Kullanicis { get; set; }
        public DbSet<KullaniciAdres>? KullaniciAdress { get; set; }
        public DbSet<Admin>? Admins { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductCategory>? ProductCategories { get; set; }


        public ECommerceDBContext(DbContextOptions<ECommerceDBContext> options) : base(options)
        {
        }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source =DESKTOP-F43C5LA\\SQLEXPRESS; Initial Catalog=EticaretWithMVC; User ID=sa;password=servet");
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            #region Kullanıcı Ve KullanıcıAdres Entityleri Fluent Api

            modelBuilder.Entity<Kullanici>() //buradada fluent api olarak tablolar arasındaki ilişkiyi belirledik..
               .HasMany(a => a.KullaniciAdress)
               .WithOne(p => p.Kullanici);

            //Burada Shadow property oluşturduk ve bunu kayıt tarihini bastık...
            
            modelBuilder.Entity<Kullanici>()
                .Property(a => a.Ad).IsRequired().HasMaxLength(50);
            modelBuilder.Entity<Kullanici>().Property(a => a.Sifre1).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Kullanici>().Property(a=>a.Sifre2).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Kullanici>().Property(a => a.KayitTarihi).HasDefaultValueSql("GETDATE()");//Kullanıcı değil biz buradan sql üzerinden değeri girdik...

            #endregion

            #region Admin Entity'si Fluent Api
            modelBuilder.Entity<Admin>().Property(p => p.Ad).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<Admin>().Property(p => p.Soyad).IsRequired().HasMaxLength(25);
            modelBuilder.Entity<Admin>().Property(p => p.Email).IsRequired().HasMaxLength(150);
           



            #endregion

            #region Seed Datalar


            modelBuilder.Entity<Kullanici>().HasData(
           new Kullanici
           {
               Id = 1,
               Ad = "Ahmet",
               Soyad = "Yılmaz",
               Sifre1 = "123456",
               Sifre2 = "123456",
               Email = "ahmet.yilmaz@mail.com",
               TelNo = "5551112233",
               KayitTarihi = DateTime.Now,
           },
           new Kullanici
           {
               Id = 2,
               Ad = "Ayşe",
               Soyad = "Kaya",
               Sifre1 = "678900",
               Sifre2 = "678900",
               Email = "ayse.kaya@mail.com",
               TelNo = "5554445566",
               KayitTarihi = DateTime.Now,
           }
             );
            modelBuilder.Entity<KullaniciAdres>().HasData(
                new KullaniciAdres()
                {Id = 1,
                    KullaniciId = 1,
                    Adresbasligi ="Ev Adresi",
                    Il ="Ankara",
                    Ilce ="Sincan",
                    Mahalle ="Yeniken",
                    AdresGenel = "Yenikent Ankara"
                });
            modelBuilder.Entity<KullaniciAdres>().HasData(
                new KullaniciAdres()
                {
                    Id = 2,
                    KullaniciId = 1,
                    Adresbasligi = "İş Adresi",
                    Il = "Ankara",
                    Ilce = "Sincan",
                    Mahalle = "Yeniken",
                    AdresGenel = "Yenikent Ankara"
                });
            modelBuilder.Entity<KullaniciAdres>().HasData(
                new KullaniciAdres()
                {Id = 3,
                    KullaniciId = 1,
                    Adresbasligi = "Dükkan Adresi",
                    Il = "Ankara",
                    Ilce = "Sincan",
                    Mahalle = "Yeniken",
                    AdresGenel = "Yenikent Ankara"
                });
            modelBuilder.Entity<KullaniciAdres>().HasData(
                new KullaniciAdres()
                {
                    Id = 4,
                    KullaniciId = 2,
                    Adresbasligi = "Ev Adresi",
                    Il = "Ankara",
                    Ilce = "Sincan",
                    Mahalle = "Yeniken",
                    AdresGenel = "Yenikent Ankara"
                });
            modelBuilder.Entity<KullaniciAdres>().HasData(
                new KullaniciAdres()
                {Id = 5,
                    KullaniciId = 2,
                    Adresbasligi = "İş Adresi",
                    Il = "Ankara",
                    Ilce = "Sincan",
                    Mahalle = "Yeniken",
                    AdresGenel = "Yenikent Ankara"
                });
            modelBuilder.Entity<KullaniciAdres>().HasData(
                new KullaniciAdres()
                {Id = 6,
                    KullaniciId = 2,
                    Adresbasligi = "Dükkan Adresi",
                    Il = "Ankara",
                    Ilce = "Sincan",
                    Mahalle = "Yeniken",
                    AdresGenel = "Yenikent Ankara"
                });


            modelBuilder.Entity<Admin>().HasData(
                    new Admin
                    {
                        Id = 3,
                        Ad = "Admin1",
                        Soyad = "Soyad1",
                        Sifre = "123456",
                        Email = "admin1@mail.com",
                        Phone = "1234567890",
                        Phone2 = "1234567890",
                        KayitTarih = DateTime.Now
                    },
                    new Admin
                    {
                        Id = 4,
                        Ad = "Admin2",
                        Soyad = "Soyad2",
                        Sifre = "654321",
                        Email = "admin2@mail.com",
                        Phone = "0987654321",
                        Phone2 = "1234567890",
                        KayitTarih = DateTime.Now,
                        
                        
                    }
                );

            
            #endregion


        }
    }
}
