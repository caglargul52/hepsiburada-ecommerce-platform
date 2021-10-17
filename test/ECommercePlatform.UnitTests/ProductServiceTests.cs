using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.Interfaces.Repositories;
using ECommercePlatform.Application.Interfaces.Services;
using ECommercePlatform.Domain.Entities;
using ECommercePlatform.Infrastructure.Services;
using Moq;
using Xunit;
using Xunit.Sdk;

namespace ECommercePlatform.UnitTests
{
    public class ProductServiceTests
    {
        private Dependencies _dependencies;

        public ProductServiceTests()
        {
            _dependencies = new Dependencies();
        }

        [Theory]
        [InlineData("P1", 100, 1000)]
        public void Is_ProductService_CreateProduct_Return_ProductInfo(string productCode, int price, int stock)
        {




            //var repository = TestStartup.ServiceProvider.GetService<IProductRepository>();
            
            //var product = new Product
            //{Id = 
            //    Code = code,
            //    Price = price,
            //    Stock = stock
            //};

            //var result = repository.AddProduct(product);
            Assert.NotEqual(1, 1);
        }
    }
}
