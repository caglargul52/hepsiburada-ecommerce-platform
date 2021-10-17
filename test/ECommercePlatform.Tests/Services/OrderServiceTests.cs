using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.DTOs.Responses;
using ECommercePlatform.Application.Exceptions;
using ECommercePlatform.Application.Interfaces.Services;
using Xunit;

namespace ECommercePlatform.Tests.Services
{
    public class OrderServiceTests
    {
        private Dependencies _dependencies;

        public OrderServiceTests()
        {
            _dependencies = new Dependencies();
        }

        [Fact]
        public async Task Is_OrderService_CreateOrder_Return_ThrowsProductNotFound()
        {
            var service = _dependencies.GetService<IOrderService>();

            CreateOrderRequest request = new CreateOrderRequest
            {
                ProductCode = "P1",
                Quantity = 2
            };

            await Assert.ThrowsAsync<NotFoundException>(
                () => service.CreateOrderAsync(request));
        }

        [Fact]
        public async Task Is_OrderService_CreateOrder_Return_ThrowsCampaignNotFound()
        {
            var productService = _dependencies.GetService<IProductService>();

            CreateProductRequest createProductRequest = new CreateProductRequest
            {
                Code = "P1",
                Price = 100,
                Stock = 1000
            };

            _ = productService.CreateProductAsync(createProductRequest);

            var orderService = _dependencies.GetService<IOrderService>();

            CreateOrderRequest request = new CreateOrderRequest
            {
                ProductCode = "P1",
                Quantity = 2
            };

            CreateOrderResponse expected = new CreateOrderResponse
            {
                ProductCode = "P1",
                Quantity = 2
            };

            var result = await orderService.CreateOrderAsync(request);

            Assert.Equal(expected.ToString(), result.ToString());
        }
    }
}
