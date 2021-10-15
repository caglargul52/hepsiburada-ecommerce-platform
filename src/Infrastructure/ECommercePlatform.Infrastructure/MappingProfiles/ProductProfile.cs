using AutoMapper;
using ECommercePlatform.Application.DTOs;
using ECommercePlatform.Domain.Entities;

namespace ECommercePlatform.Infrastructure.MappingProfiles
{
    class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductResponseDto>().ReverseMap();

            CreateMap<Product, ProductRequestDto>().ReverseMap();
        }
    }
}
