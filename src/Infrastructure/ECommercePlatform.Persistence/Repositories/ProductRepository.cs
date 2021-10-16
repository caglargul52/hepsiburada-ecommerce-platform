using System.Threading.Tasks;
using ECommercePlatform.Application.Interfaces.Repositories;
using ECommercePlatform.Domain.Entities;
using ECommercePlatform.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommercePlatform.Persistence.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Product> GetByProductCodeAsync(string productCode)
        {
            return await Context.Products.FirstOrDefaultAsync(x => x.Code == productCode);
        }
    }
}
