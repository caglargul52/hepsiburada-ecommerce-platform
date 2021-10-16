using ECommercePlatform.Application.Wrapper;
using MediatR;

namespace ECommercePlatform.Application.DTOs.Requests
{
    public class GetCampaignRequest : IRequest<Result>
    {
        public string Name { get; set; }
    }
}
