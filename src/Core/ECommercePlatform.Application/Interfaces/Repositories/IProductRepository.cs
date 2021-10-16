using System.Threading.Tasks;
using ECommercePlatform.Domain.Entities;

namespace ECommercePlatform.Application.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetByProductCodeAsync(string productCode);
    }
}
