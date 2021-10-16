using AutoMapper;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.DTOs.Responses;
using ECommercePlatform.Domain.Entities;

namespace ECommercePlatform.Infrastructure.MappingProfiles
{
    class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, CreateProductRequest>().ReverseMap();

            CreateMap<Product, CreateProductResponse>().ReverseMap();

            CreateMap<Product, GetProductResponse>().ReverseMap();
        }
    }
}
