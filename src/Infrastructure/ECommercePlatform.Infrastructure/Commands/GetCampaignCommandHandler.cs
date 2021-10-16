using System;
using System.Threading;
using System.Threading.Tasks;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.Interfaces.Services;
using ECommercePlatform.Application.Wrapper;
using MediatR;

namespace ECommercePlatform.Infrastructure.Commands
{
    public class GetCampaignCommandHandler : IRequestHandler<GetCampaignRequest, Result>
    {
        private readonly ICampaignService _campaignService;

        public GetCampaignCommandHandler(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }

        public async Task<Result> Handle(GetCampaignRequest request, CancellationToken cancellationToken)
        {
            Result result = new Result();

            try
            {
                var campaign = await _campaignService.GetCampaign(request);

                result.IsSuccess = true;
                result.Message = campaign.ToString();
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }

            return result;
        }
    }
}
