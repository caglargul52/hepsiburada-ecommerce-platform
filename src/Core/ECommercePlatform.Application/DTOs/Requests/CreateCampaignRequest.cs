using ECommercePlatform.Application.Wrapper;
using MediatR;

namespace ECommercePlatform.Application.DTOs.Requests
{
    public class CreateCampaignRequest : IRequest<CommandResult>
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public decimal ManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
    }
}
