using System;
using System.Threading.Tasks;
using AutoMapper;
using ECommercePlatform.Application.DTOs;
using ECommercePlatform.Application.Interfaces.Repositories;
using ECommercePlatform.Application.Services;
using ECommercePlatform.Domain.Entities;

namespace ECommercePlatform.Infrastructure
{
    public class ProductService : IProductService
    {
        private readonly IMapper _mapper;
        private readonly IProductRepository _productRepository;

        public ProductService(IMapper mapper, IProductRepository productRepository)
        {
            _mapper = mapper;
            _productRepository = productRepository;
        }


        public Task<ProductResponseDto> Get(string productCode)
        {
            throw new NotImplementedException();
        }

        public async Task<ProductResponseDto> Create(ProductRequestDto model)
        {
            throw new NotImplementedException();
        }

        public Task DecreaseStock(ProductRequestDto model, int quantity)
        {
            throw new NotImplementedException();
        }
    }
}
