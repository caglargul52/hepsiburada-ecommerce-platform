using ECommercePlatform.Application.Interfaces.Repositories;
using ECommercePlatform.Domain.Entities;
using ECommercePlatform.Persistence.Contexts;

namespace ECommercePlatform.Persistence.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationContext context) : base(context)
        {
        }
    }
}
