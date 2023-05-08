using ECommerceWithMVC.Models.Database_Factory;
using System.ComponentModel.DataAnnotations.Schema;

namespace ECommerceWithMVC.Models.Entities
{
    [Table("Admins")]
    public class Admin : IEntities
    {       
        public int Id { get; set; }
        public string? Ad { get; set; }
        public string? Soyad { get; set;}
        public string? Sifre { get; set; }
        public string? Email { get; set;}
        public string? Phone { get; set; }
        public string? Phone2 { get; set; }
        public DateTime? KayitTarih { get; set; }

        public void run()
        {
            throw new NotImplementedException();
        }
    }
}
