using System;
using System.Threading.Tasks;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.DTOs.Responses;
using ECommercePlatform.Application.Exceptions;
using ECommercePlatform.Application.Interfaces.Services;
using Xunit;

namespace ECommercePlatform.Tests.Services
{
    public class CampaignServiceTests
    {
        private Dependencies _dependencies;

        public CampaignServiceTests()
        {
            _dependencies = new Dependencies();
        }

        [Fact]
        public async Task Is_CampaignService_CreateCampaign_Return_ThrowsProductNotFound()
        {
            CreateCampaignRequest request = new CreateCampaignRequest
            {
                Name = "C1",
                ManipulationLimit = 20,
                ProductCode = "P1",
                TargetSalesCount = 100,
                Duration = 5
            };

            var service = _dependencies.GetService<ICampaignService>();

            await Assert.ThrowsAsync<NotFoundException>(
                () => service.CreateCampaignAsync(request));
        }

        [Fact]
        public async Task Is_CampaignService_CreateCampaign_Return_CampaignInfo()
        {
            var productService = _dependencies.GetService<IProductService>();

            var campaignService = _dependencies.GetService<ICampaignService>();

            CreateProductRequest createProductRequest = new CreateProductRequest
            {
                Code = "P1",
                Price = 100,
                Stock = 1000
            };

            _ = productService.CreateProductAsync(createProductRequest);


            CreateCampaignRequest createCampaignRequest = new CreateCampaignRequest
            {
                Name = "C1",
                ManipulationLimit = 20,
                ProductCode = "P1",
                TargetSalesCount = 100,
                Duration = 5
            };

            CreateCampaignResponse expectedResponse = new CreateCampaignResponse
            {
                Name = "C1",
                ManipulationLimit = 20,
                ProductCode = "P1",
                TargetSalesCount = 100,
                Duration = 5
            };

            var result = await campaignService.CreateCampaignAsync(createCampaignRequest);

            Assert.Equal(expectedResponse.ToString(), result.ToString());
        }

        [Fact]
        public async Task Is_CampaignService_GetCampaign_Return_ThrowsCampaignNotFound()
        {
            var service = _dependencies.GetService<ICampaignService>();

            GetCampaignRequest getRequest = new GetCampaignRequest
            {
                Name = "C1"
            };

            await Assert.ThrowsAsync<NotFoundException>(
                () => service.GetCampaignAsync(getRequest));
        }

        [Fact]
        public async Task Is_CampaignService_GetCampaign_Return_CampaignInfo()
        {
            var campaignService = _dependencies.GetService<ICampaignService>();

            var productService = _dependencies.GetService<IProductService>();

            CreateProductRequest createProductRequest = new CreateProductRequest
            {
                Code = "P1",
                Price = 100,
                Stock = 1000
            };

            _ = productService.CreateProductAsync(createProductRequest);

            CreateCampaignRequest createCampaignRequest = new CreateCampaignRequest
            {
                Name = "C1",
                ManipulationLimit = 20,
                ProductCode = "P1",
                TargetSalesCount = 100,
                Duration = 5
            };

            _ = await campaignService.CreateCampaignAsync(createCampaignRequest);

            GetCampaignRequest getRequest = new GetCampaignRequest
            {
                Name = "C1"
            };

            GetCampaignResponse expected = new GetCampaignResponse
            {
                TargetSalesCount = 100,
                Name = "C1",
                AvarageItemPrice = 0,
                IsActive = true,
                TotalSalesCount = 0,
                TurnOver = 0
            };

            var result = await campaignService.GetCampaignAsync(getRequest);

            Assert.Equal(expected.ToString(), result.ToString());
        }
    }
}
