using ECommercePlatform.Application.Wrapper;
using MediatR;

namespace ECommercePlatform.Application.DTOs.Requests
{
    public class IncreaseTimeRequest : IRequest<CommandResult>
    {
        public int Hour { get; set; }
    }
}
