using ECommerceWithMVC.Models.DataContext;
using ECommerceWithMVC.Models.Entities;

namespace ECommerceWithMVC.Repositories
{
    public class GenericRepository<Entity> where Entity : class,new()
    {
        
        public List<Entity> AdresListe(Kullanici kullanici)
        {
            return null;
        }
    }
}
