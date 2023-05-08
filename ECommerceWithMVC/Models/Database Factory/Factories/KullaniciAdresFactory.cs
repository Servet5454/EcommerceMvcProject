using ECommerceWithMVC.Models.Entities;

namespace ECommerceWithMVC.Models.Database_Factory.Concrete_Factories
{
    public class KullaniciAdresFactory : IDataBaseFactory
    {
        public IEntities Createinstance()
        {
            KullaniciAdres kullaniciAdres = new KullaniciAdres();
            return kullaniciAdres;
        }
    }
}
