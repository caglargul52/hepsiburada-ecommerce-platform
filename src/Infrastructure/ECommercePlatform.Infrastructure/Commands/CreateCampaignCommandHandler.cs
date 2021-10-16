using System;
using System.Threading;
using System.Threading.Tasks;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.Interfaces.Services;
using ECommercePlatform.Application.Wrapper;
using MediatR;

namespace ECommercePlatform.Infrastructure.Commands
{
    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignRequest, CommandResult>
    {
        private readonly ICampaignService _campaignService;

        public CreateCampaignCommandHandler(ICampaignService campaignService)
        {
            _campaignService = campaignService;
        }
        public async Task<CommandResult> Handle(CreateCampaignRequest request, CancellationToken cancellationToken)
        {
            CommandResult commandResult = new CommandResult();

            try
            {
                var campaign = await _campaignService.CreateCampaign(request);

                commandResult.IsSuccess = true;
                commandResult.Message = campaign.ToString();
            }
            catch (Exception e)
            {
                commandResult.IsSuccess = false;
                commandResult.Message = e.Message;
            }

            return commandResult;
        }
    }
}
