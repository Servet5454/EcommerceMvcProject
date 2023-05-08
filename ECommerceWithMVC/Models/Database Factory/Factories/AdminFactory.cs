using ECommerceWithMVC.Models.Entities;

namespace ECommerceWithMVC.Models.Database_Factory.Concrete_Factories
{
    public class AdminFactory : IDataBaseFactory
    {
        public IEntities Createinstance()
        {
            Admin admin = new Admin();
            return admin;

        }
    }





}
