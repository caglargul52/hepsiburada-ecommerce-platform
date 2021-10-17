using System;
using System.Threading.Tasks;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.DTOs.Responses;
using ECommercePlatform.Domain.Entities;

namespace ECommercePlatform.Application.Interfaces.Services
{
    public interface IProductService
    {
        Task<GetProductResponse> GetProductAsync(GetProductRequest model);
        Task<Product> GetProductByCodeAsync(string productCode);
        Task<CreateProductResponse> CreateProductAsync(CreateProductRequest model);
        decimal CalculateCampaignProductPrice(decimal price, decimal manipulationLimit, int duration, DateTime campaignStartedDate);
        Task<Product> DecreaseStockAsync(Product model, int quantity);
    }
}
