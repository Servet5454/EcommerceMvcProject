using ECommerceWithMVC.Models.Database_Factory;
using ECommerceWithMVC.Models.Database_Factory.Concrete_Factories;
using ECommerceWithMVC.Models.Entities;

namespace ECommerceWithMVC.Models
{


    public class EntityCreater
    {
        public IEntities GetInstance(EntitiesType entityType)
        {

            IDataBaseFactory _factory = entityType switch
            {
                EntitiesType.Admin => new AdminFactory(),
                EntitiesType.Kullanici => new KullaniciFactory(),
                EntitiesType.KullaniciAdres => new KullaniciAdresFactory(),
                _ => throw new NotImplementedException(),
            };
            return _factory.Createinstance();

        }
        public enum EntitiesType
        {
            Admin, Kullanici, KullaniciAdres,

        }
    }
}
