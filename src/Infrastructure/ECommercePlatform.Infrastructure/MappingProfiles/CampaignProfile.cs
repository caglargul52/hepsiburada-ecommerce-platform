using AutoMapper;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.DTOs.Responses;
using ECommercePlatform.Domain.Entities;

namespace ECommercePlatform.Infrastructure.MappingProfiles
{
    class CampaignProfile : Profile
    {
        public CampaignProfile()
        {
            CreateMap<Campaign, CreateCampaignRequest>().ReverseMap();

            CreateMap<CreateCampaignResponse, Campaign>().ReverseMap();

        }
    }
}
