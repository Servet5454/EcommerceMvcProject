using ECommerceWithMVC.Models.Entities;

namespace ECommerceWithMVC.Models.ViewModel
{
    public class AdreslerViewModel
    {
        public int Id { get; set; }
        public int KullaniciId { get; set; } //bu yaptığımız tanımlama ile foreign key tanımlamış oluyoruz...
        public string? Adresbasligi { get; set; }
        public string? Il { get; set; }
        public string? Ilce { get; set; }
        public string? Mahalle { get; set; }
        public string? AdresGenel { get; set; }

       
    }
}
