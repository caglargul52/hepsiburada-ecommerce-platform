using System.Threading.Tasks;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.DTOs.Responses;
using ECommercePlatform.Domain.Entities;

namespace ECommercePlatform.Application.Interfaces.Services
{
    public interface ICampaignService
    {
        Task<CreateCampaignResponse> CreateCampaignAsync(CreateCampaignRequest model);
        Task<GetCampaignResponse> GetCampaignAsync(GetCampaignRequest model);
        Task<Campaign> GetCampaignByNameAsync(string campaignName);
        Task<Campaign> GetCampaignByProductCode(string productCode);
        bool IsCampaignActiveAsync(Campaign campaign);
        Task<Campaign> DecreaseRemainingTargetAsync(Campaign campaign, int quantity);
    }
}
