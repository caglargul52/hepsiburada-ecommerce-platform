using System.Threading;
using System.Threading.Tasks;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.Interfaces.Services;
using ECommercePlatform.Application.Wrapper;
using MediatR;

namespace ECommercePlatform.Infrastructure.Commands
{
    public class IncreaseTimeCommandHandler : IRequestHandler<IncreaseTimeRequest, CommandResult>
    {
        private readonly ITimeManagementService _timeManagementService;

        public IncreaseTimeCommandHandler(ITimeManagementService timeManagementService)
        {
            _timeManagementService = timeManagementService;
        }

        public Task<CommandResult> Handle(IncreaseTimeRequest request, CancellationToken cancellationToken)
        {
            CommandResult commandResult = new CommandResult();

            var dateTime = _timeManagementService.IncreaseTime(request.Hour);

            commandResult.IsSuccess = true;

            commandResult.Message = $"Time is {dateTime.ToShortTimeString()}";

            return Task.FromResult(commandResult);
        }
    }
}
