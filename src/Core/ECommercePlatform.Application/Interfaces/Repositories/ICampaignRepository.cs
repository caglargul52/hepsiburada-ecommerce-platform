using System.Threading.Tasks;
using ECommercePlatform.Domain.Entities;

namespace ECommercePlatform.Application.Interfaces.Repositories
{
    public interface ICampaignRepository : IRepository<Campaign>
    {
        Task<Campaign> GetByProductCodeAsync(string productCode);
        Task<Campaign> GetByNameAsync(string campaignName);

    }
}
