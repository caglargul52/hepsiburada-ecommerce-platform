using System.Threading.Tasks;
using ECommercePlatform.Application.DTOs;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.DTOs.Responses;
using ECommercePlatform.Domain.Entities;

namespace ECommercePlatform.Application.Interfaces.Services
{
    public interface ICampaignService
    {
        Task<CreateCampaignResponse> CreateCampaign(CreateCampaignRequest model);
        Task<GetCampaignResponse> GetCampaign(GetCampaignRequest model);
        Task<Campaign> GetCampaignByName(string campaignName);
        Task<Campaign> GetCampaignByProductCode(string productCode);
        bool IsCampaignActive(Campaign campaign);
        Task<Campaign> DecreaseRemainingTarget(Campaign campaign, int quantity);
    }
}
