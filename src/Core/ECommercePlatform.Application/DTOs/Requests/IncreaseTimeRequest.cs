using ECommercePlatform.Application.Wrapper;
using MediatR;

namespace ECommercePlatform.Application.DTOs.Requests
{
    public class IncreaseTimeRequest : IRequest<Result>
    {
        public int Hour { get; set; }
    }
}
