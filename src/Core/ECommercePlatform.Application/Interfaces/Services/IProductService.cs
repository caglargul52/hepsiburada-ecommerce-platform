using System;
using System.Threading.Tasks;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.DTOs.Responses;
using ECommercePlatform.Domain.Entities;

namespace ECommercePlatform.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<GetProductResponse> GetProduct(GetProductRequest model);
        Task<Product> GetProductByCode(string productCode);
        Task<CreateProductResponse> CreateProduct(CreateProductRequest model);
        decimal CalculateCampaignProductPrice(decimal price, decimal manipulationLimit, int duration, DateTime campaignStartedDate);
        Task<Product> DecreaseStock(Product model, int quantity);
    }
}
