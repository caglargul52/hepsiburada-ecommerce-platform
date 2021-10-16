using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.DTOs.Responses;
using ECommercePlatform.Application.Exceptions;
using ECommercePlatform.Application.Interfaces.Repositories;
using ECommercePlatform.Application.Interfaces.Services;
using ECommercePlatform.Domain.Entities;

namespace ECommercePlatform.Infrastructure.Services
{
    class CampaignService : ICampaignService
    {
        private readonly IMapper _mapper;
        private readonly ICampaignRepository _campaignRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly ITimeManagementService _timeManagementService;

        public CampaignService(IMapper mapper, ICampaignRepository campaignRepository, IOrderRepository orderRepository, ITimeManagementService timeManagementService)
        {
            _mapper = mapper;
            _campaignRepository = campaignRepository;
            _orderRepository = orderRepository;
            _timeManagementService = timeManagementService;
        }

        public async Task<CreateCampaignResponse> CreateCampaign(CreateCampaignRequest model)
        {
            if (model is null)
                throw new NullReferenceException("Invalid parameter!");

            //Todo:FluentValidation kulanılarak Dtonun parametreleri validasyon yapılabilir.

            var campaign = _mapper.Map<Campaign>(model);

            campaign.RemainingTarget = model.TargetSalesCount;
            campaign.StartDate = _timeManagementService.GetDate();
            campaign.EndDate = campaign.StartDate.AddHours(campaign.Duration);

            var addedCampaign = await _campaignRepository.AddAsync(campaign);

            return _mapper.Map<CreateCampaignResponse>(addedCampaign);
        }

        public async Task<GetCampaignResponse> GetCampaign(GetCampaignRequest model)
        {
            if (model is null)
                throw new NullReferenceException("Invalid parameter!");

            //Todo:FluentValidation kulanılarak Dtonun parametreleri validasyon yapılabilir.

            var campaign = await _campaignRepository.GetByNameAsync(model.Name);

            if (campaign is null)
                throw new NotFoundException("Campaign is not found!");

            var orders = await _orderRepository.WhereAsync(x => x.CampaignName == model.Name);

            var totalOrderCount = orders.Sum(q => q.Quantity);

            var sumPrice = orders.Sum(q => q.Price);

            var response = new GetCampaignResponse
            {
                Name = campaign.Name,
                IsActive = IsCampaignActive(campaign) && totalOrderCount < campaign.TargetSalesCount,
                TotalSalesCount = totalOrderCount,
                TargetSalesCount = campaign.TargetSalesCount,
                AvarageItemPrice = totalOrderCount > 0 ? sumPrice / totalOrderCount : 0,
                TurnOver = totalOrderCount > 0 ? (int)(sumPrice / totalOrderCount) * totalOrderCount : 0
            };

            return response;
        }

        public async Task<Campaign> GetCampaignByName(string campaignName)
        {
            return await _campaignRepository.GetByNameAsync(campaignName);
        }

        public async Task<Campaign> GetCampaignByProductCode(string productCode)
        {
            return await _campaignRepository.GetByProductCodeAsync(productCode);
        }

        public bool IsCampaignActive(Campaign campaign)
        {
            var dateTimeNow = _timeManagementService.GetDate();

            if (campaign != null)
            {
                return campaign.StartDate <= dateTimeNow && dateTimeNow <= campaign.EndDate;
            }

            return false;
        }

        public async Task<Campaign> DecreaseRemainingTarget(Campaign campaign, int quantity)
        {
            campaign.RemainingTarget -= quantity;

            return await _campaignRepository.UpdateAsync(campaign);
        }
    }
}
