using System.Threading;
using System.Threading.Tasks;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.Interfaces.Services;
using ECommercePlatform.Application.Wrapper;
using MediatR;

namespace ECommercePlatform.Infrastructure.Commands
{
    public class IncreaseTimeCommandHandler : IRequestHandler<IncreaseTimeRequest, Result>
    {
        private readonly ITimeManagementService _timeManagementService;

        public IncreaseTimeCommandHandler(ITimeManagementService timeManagementService)
        {
            _timeManagementService = timeManagementService;
        }

        public Task<Result> Handle(IncreaseTimeRequest request, CancellationToken cancellationToken)
        {
            Result result = new Result();

            var dateTime = _timeManagementService.IncreaseTime(request.Hour);

            result.IsSuccess = true;

            result.Message = $"Time is {dateTime.ToShortTimeString()}";

            return Task.FromResult(result);
        }
    }
}
