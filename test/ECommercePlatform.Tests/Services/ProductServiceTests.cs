using System;
using System.Threading.Tasks;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.DTOs.Responses;
using ECommercePlatform.Application.Interfaces.Services;
using Xunit;

namespace ECommercePlatform.Tests.Services
{
    public class ProductServiceTests
    {
        private Dependencies _dependencies;

        public ProductServiceTests()
        {
            _dependencies = new Dependencies();
        }

        [Fact]
        public async Task Is_ProductService_CreateProduct_Return_ProductInfo()
        {
            CreateProductRequest request = new CreateProductRequest
            {
                Code = "P1",
                Price = 100,
                Stock = 1000
            };

            CreateProductResponse expectedResponse = new CreateProductResponse
            {
                Code = "P1",
                Price = 100,
                Stock = 1000
            };

            var service = _dependencies.GetService<IProductService>();

            var result = await service.CreateProductAsync(request);

            Assert.Equal(expectedResponse.ToString(), result.ToString());
        }

        [Fact]
        public async Task Is_ProductService_GetProduct_Return_ThrowException()
        {
            GetProductRequest getRequest = new GetProductRequest
            {
                Code = "P1"
            };

            var service = _dependencies.GetService<IProductService>();
            
            await Assert.ThrowsAsync<NullReferenceException>(
                () => service.GetProductAsync(getRequest));
        }

        [Fact]
        public async Task Is_ProductService_GetProduct_Return_ProdcutInfo()
        {
            var service = _dependencies.GetService<IProductService>();

            GetProductRequest getRequest = new GetProductRequest
            {
                Code = "P1"
            };

            CreateProductRequest createRequest = new CreateProductRequest
            {
                Code = "P1",
                Price = 100,
                Stock = 1000
            };

            var result = await service.CreateProductAsync(createRequest);

            var result2 = await service.GetProductAsync(getRequest);

            GetProductResponse expectedResponse = new GetProductResponse
            {
                Code = "P1",
                Stock = 1000,
                CampaignPrice = 100
            };

            Assert.Equal(expectedResponse.ToString(), result2.ToString());
        }

        [Fact]
        public async Task Is_ProductService_GetProductWithCampaignOneHour_Return_ProdcutInfo()
        {
            var productService = _dependencies.GetService<IProductService>();

            var campaignService = _dependencies.GetService<ICampaignService>();

            var timeService = _dependencies.GetService<ITimeManagementService>();


            GetProductRequest getProductRequest = new GetProductRequest
            {
                Code = "P1"
            };

            CreateProductRequest createProductRequest = new CreateProductRequest
            {
                Code = "P1",
                Price = 100,
                Stock = 1000
            };

            CreateCampaignRequest createCampaignRequest = new CreateCampaignRequest
            {
                Name = "C1",
                Duration = 5,
                ManipulationLimit = 20,
                ProductCode = "P1",
                TargetSalesCount = 100
            };

            _ = await productService.CreateProductAsync(createProductRequest);

            _ = await campaignService.CreateCampaignAsync(createCampaignRequest);

            _ = timeService.IncreaseTime(1);

            var result2 = await productService.GetProductAsync(getProductRequest);

            GetProductResponse expectedResponse = new GetProductResponse
            {
                Code = "P1",
                Stock = 1000,
                CampaignPrice = 84
            };

            Assert.Equal(expectedResponse.ToString(), result2.ToString());
        }
    }
}
