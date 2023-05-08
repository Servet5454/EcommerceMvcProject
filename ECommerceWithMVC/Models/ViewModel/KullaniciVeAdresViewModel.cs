using ECommerceWithMVC.Models.Entities;

namespace ECommerceWithMVC.Models.ViewModel
{
    public class KullaniciVeAdresViewModel
    {
        public int Id { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set; }
        public string? Sifre1 { get; set; }
        public string? Sifre2 { get; set; }
        public string? Email { get; set; }
        public string? TelNo { get; set; }
        public string? Adresbasligi { get; set; }
        public string? Il { get; set; }
        public string? Ilce { get; set; }
        public string? Mahalle { get; set; }
        public string? AdresGenel { get; set; }
        public DateTime? KayitTarihi { get; set; }
       
    }
}
