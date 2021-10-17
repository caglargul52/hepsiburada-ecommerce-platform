using System;
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
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _orderRepository;
        private readonly IProductService _productService;
        private readonly ICampaignService _campaignService;


        public OrderService(IMapper mapper, IOrderRepository orderRepository, IProductService productService, ICampaignService campaignService)
        {
            _mapper = mapper;
            _orderRepository = orderRepository;
            _productService = productService;
            _campaignService = campaignService;
        }

        public async Task<CreateOrderResponse> CreateOrderAsync(CreateOrderRequest model)
        {
            if (model is null)
                throw new NullReferenceException("Invalid parameter!");

            var product = await _productService.GetProductByCodeAsync(model.ProductCode);

            if (product is null)
                throw new NotFoundException("Product is not found!");

            //Todo:FluentValidation kulanılarak Dtonun parametreleri validasyon yapılabilir.

            product = await _productService.DecreaseStockAsync(product, model.Quantity);

            var order = _mapper.Map<Order>(model);

            var campaign = await _campaignService.GetCampaignByProductCode(product.Code);

            if (campaign is null) 
                return await AddOrder(order);

            var campaignIsValid = _campaignService.IsCampaignActiveAsync(campaign);

            if (campaignIsValid && campaign.RemainingTarget > model.Quantity)
            {
                product.CampaignPrice =  _productService.CalculateCampaignProductPrice(product.Price, campaign.ManipulationLimit, campaign.Duration, campaign.StartDate);

                order.CampaignName = campaign.Name;
                
                _ = _campaignService.DecreaseRemainingTargetAsync(campaign, model.Quantity);
            }

            order.Price = product.CampaignPrice * model.Quantity;

            return await AddOrder(order);
        }

        private async Task<CreateOrderResponse> AddOrder(Order order)
        {
            var addedOrder = await _orderRepository.AddAsync(order);

            return _mapper.Map<CreateOrderResponse>(addedOrder);
        }
    }
}
