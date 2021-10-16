using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.Interfaces.Repositories;
using ECommercePlatform.Application.Interfaces.Services;
using ECommercePlatform.Application.Wrapper;
using MediatR;

namespace ECommercePlatform.Infrastructure.Commands
{
    public class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignRequest, Result>
    {
        private readonly IMapper _mapper;
        private readonly ICampaignRepository _campaignRepository;
        private readonly ITimeManagementService _timeManagementService;
        private readonly ICampaignService _campaignService;


        public CreateCampaignCommandHandler(IMapper mapper, ICampaignRepository campaignRepository, ITimeManagementService timeManagementService, ICampaignService campaignService)
        {
            _mapper = mapper;
            _campaignRepository = campaignRepository;
            _timeManagementService = timeManagementService;
            _campaignService = campaignService;
        }
        public async Task<Result> Handle(CreateCampaignRequest request, CancellationToken cancellationToken)
        {
            Result result = new Result();

            try
            {
                var campaign = await _campaignService.CreateCampaign(request);

                result.IsSuccess = true;
                result.Message = campaign.ToString();
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }

            return result;

            //Result result = new Result();

            //if (request is null)
            //{
            //    result.IsSuccess = false;
            //    result.Message = "Request failed!";

            //    return result;
            //}

            ////Todo:FluentValidation kulanılarak Dtonun parametreleri validasyon yapılabilir.

            //var campaign = _mapper.Map<Campaign>(request);

            //campaign.RemainingTarget = request.TargetSalesCount;
            //campaign.StartDate = _timeManagementService.GetDate();
            //campaign.EndDate = campaign.StartDate.AddHours(campaign.Duration);

            //bool status = await _campaignRepository.AddAsync(campaign);

            //if (status)
            //{
            //    result.IsSuccess = true;
            //    result.Message = $"Campaign created; name {campaign.Name}, product {campaign.ProductCode}, duration {campaign.Duration}, limit {campaign.ManipulationLimit}, target sales count {campaign.TargetSalesCount}";
            //    return result;
            //}

            //result.IsSuccess = false;
            //result.Message = "Request failed!";

            //return result;
        }
    }
}
