using ECommerceWithMVC.Models.Entities;

namespace ECommerceWithMVC.Models.Database_Factory.Concrete_Factories
{
    public class KullaniciFactory : IDataBaseFactory
    {
        public IEntities Createinstance()
        {
           Kullanici K1 = new Kullanici();
            return K1;
        }
    }
}
