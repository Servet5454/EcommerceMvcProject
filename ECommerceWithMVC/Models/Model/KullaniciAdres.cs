using ECommerceWithMVC.Models.Database_Factory;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceWithMVC.Models.Entities
{
    // Her ne kadar bizler foreign key tanımlamasakta ilişki tipini yaptıktan sonra Ef core kendisi otomatik tanımlar...
    //biz yinede kendimiz tanımlayacağız..
    [Table("KullaniciAdress")]
    public class KullaniciAdres : IEntities
    {
       
        public int Id { get; set; }       
        public int KullaniciId { get; set; } //bu yaptığımız tanımlama ile foreign key tanımlamış oluyoruz...
        public string? Adresbasligi { get; set; }
        public string? Il { get; set; }
        public string? Ilce { get; set; }
        public string? Mahalle { get; set; }
        public string? AdresGenel { get; set;}

        public Kullanici? Kullanici { get; set; } //Burada kullanıcı entity'si ile ilişkisini yaptık...

        public void run()
        {
            throw new NotImplementedException();
        }
    }
}
