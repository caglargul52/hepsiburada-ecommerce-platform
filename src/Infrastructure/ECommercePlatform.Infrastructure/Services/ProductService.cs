using System;
using System.Threading.Tasks;
using AutoMapper;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.DTOs.Responses;
using ECommercePlatform.Application.Interfaces.Repositories;
using ECommercePlatform.Application.Interfaces.Services;
using ECommercePlatform.Domain.Entities;

namespace ECommercePlatform.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;
        private readonly ICampaignService _campaignService;
        private readonly ITimeManagementService _timeManagementService;
        
        public ProductService(IMapper mapper, IProductRepository productRepository, ICampaignService campaignService, ITimeManagementService timeManagementService)
        {
            _mapper = mapper;
            _productRepository = productRepository;
            _campaignService = campaignService;
            _timeManagementService = timeManagementService;
        }

        public async Task<CreateProductResponse> CreateProductAsync(CreateProductRequest model)
        {
            if (model is null)
                throw new NullReferenceException("Invalid parameter!");

            //Todo:FluentValidation kulanılarak Dtonun parametreleri validasyon yapılabilir.

            var product = _mapper.Map<Product>(model);

            product.CampaignPrice = product.Price;

            var addedProduct = await _productRepository.AddAsync(product);

            return _mapper.Map<CreateProductResponse>(addedProduct);
        }

        public async Task<GetProductResponse> GetProductAsync(GetProductRequest model)
        {
            var product = await _productRepository.GetByProductCodeAsync(model.Code);

            if (product is null)
                throw new NullReferenceException("Invalid parameter!");
            
            product.CampaignPrice = product.Price;

            var campaign = await _campaignService.GetCampaignByProductCode(model.Code);

            if (campaign is null)
                return _mapper.Map<GetProductResponse>(product);

            if (_campaignService.IsCampaignActiveAsync(campaign) && campaign.RemainingTarget > 0)
                product.CampaignPrice = CalculateCampaignProductPrice(product.Price, campaign.ManipulationLimit, campaign.Duration, campaign.StartDate);
            

            return _mapper.Map<GetProductResponse>(product);
        }

        public async Task<Product> GetProductByCodeAsync(string productCode)
        {
            return await _productRepository.GetByProductCodeAsync(productCode);
        }

        public decimal CalculateCampaignProductPrice(decimal price, decimal manipulationLimit, int duration, DateTime campaignStartedDate)
        {
            //Kampanyalar gece 00:00 da başladığı için satın alma potansiyeli yüksek olan saatler kampanyanın ilk saatlerine denk gelmektedir. 
            //Bu yüzden daha fazla ürün satılması için indirim oranı maksimumla başlayıp zamanla orantılı olarak azalan bir algoritma tercih edilmiştir.

            var discountedHours = _timeManagementService.DiscountedHours(campaignStartedDate);

            var discountRatio = (price * manipulationLimit) / 100;

            var maxCampaignPrice = price - discountRatio;

            var increaseLimit = discountRatio / duration;

            var discountPrice = increaseLimit * discountedHours;

            return maxCampaignPrice + discountPrice;
        }

        public async Task<Product> DecreaseStockAsync(Product model, int quantity)
        {
            model.Stock -= quantity;

            return await _productRepository.UpdateAsync(model);
        }
    }
}
