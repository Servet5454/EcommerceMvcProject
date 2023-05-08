using ECommerceWithMVC.Models.Database_Factory;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Cryptography;

namespace ECommerceWithMVC.Models.Entities
{
    //Kullanıcı Entity'si İle Kullanıcı Adres Arasında Bire Çok Yani( One To Many İlişkisi Kuracağız Bu ilişkiyi Fluent Api Üzerinden Kurup Bu Entity Üzerinde Çok Kalabalık yapmak İstemiyorum ama  Property aracılığı ile nasıl Bu İlişki Kurulur Onuda göstermeye Çalışacağım...)
    [Table("Kullanicis")]
    public class Kullanici : IEntities
    {
        public Kullanici()
        {
            KullaniciAdress =new HashSet<KullaniciAdres>();
        }

        public int Id { get; set; }
        public string? Ad { get; set; }
  
        public string? Soyad { get; set; }
        public string? Sifre1 { get; set; }
        public string? Sifre2 { get; set; }
        public string? Email { get; set; }
        public string? TelNo { get; set; }
        public DateTime? KayitTarihi { get; set; } =DateTime.Now;

        public ICollection<KullaniciAdres>? KullaniciAdress { get; set; } //burada kullanıcı adresle çok ilişkisi olduğunu söyledik...
       

        public void run()
        {
            throw new NotImplementedException();
        }
    }

   
}
