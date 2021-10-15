using System.Threading.Tasks;
using ECommercePlatform.Application.DTOs;

namespace ECommercePlatform.Application.Services
{
    public interface IProductService
    {
        Task<ProductResponseDto> Get(string productCode);
        Task<ProductResponseDto> Create(ProductRequestDto model);
        Task DecreaseStock(ProductRequestDto model, int quantity);
    }
}
