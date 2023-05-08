using ECommerceWithMVC.Models.Database_Factory;

namespace ECommerceWithMVC.Models.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string? Isim { get; set; }
        public string? Aciklama { get; set; }       
        public decimal? Fiyat { get; set; }
        public int StokAdedi { get; set; }
        //public List<string>? ImageUrls { get; set; }
        //public Dictionary<string, string>? Attributes { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public DateTime GuncellemeTarihi { get; set; }
        public ProductCategory? ProductCategory { get; set; }
    }
}
