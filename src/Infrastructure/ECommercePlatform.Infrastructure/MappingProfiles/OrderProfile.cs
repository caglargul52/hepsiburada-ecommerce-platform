using AutoMapper;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.DTOs.Responses;
using ECommercePlatform.Domain.Entities;

namespace ECommercePlatform.Infrastructure.MappingProfiles
{
    class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, CreateOrderRequest>().ReverseMap();

            CreateMap<Order, CreateOrderResponse>().ReverseMap();

        }
    }
}
