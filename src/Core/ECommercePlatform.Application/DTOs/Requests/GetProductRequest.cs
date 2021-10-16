using ECommercePlatform.Application.Wrapper;
using MediatR;

namespace ECommercePlatform.Application.DTOs.Requests
{
    public class GetProductRequest : IRequest<CommandResult>
    {
        public string Code { get; set; }
    }
}
