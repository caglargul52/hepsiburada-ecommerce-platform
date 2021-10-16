using System.Threading.Tasks;
using ECommercePlatform.Application.Interfaces.Repositories;
using ECommercePlatform.Domain.Entities;
using ECommercePlatform.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommercePlatform.Persistence.Repositories
{
    public class CampaignRepository : Repository<Campaign>, ICampaignRepository
    {
        public CampaignRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<Campaign> GetByProductCodeAsync(string productCode)
        {
            return await Context.Set<Campaign>().FirstOrDefaultAsync(x => x.ProductCode == productCode);
        }

        public async Task<Campaign> GetByNameAsync(string campaignName)
        {
            return await Context.Set<Campaign>().FirstOrDefaultAsync(x => x.Name == campaignName);
        }
    }
}
