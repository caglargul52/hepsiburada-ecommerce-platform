using System.Threading.Tasks;
using ECommercePlatform.Application.Interfaces.Repositories;
using ECommercePlatform.Domain.Entities;
using ECommercePlatform.Persistence.Contexts;

namespace ECommercePlatform.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
