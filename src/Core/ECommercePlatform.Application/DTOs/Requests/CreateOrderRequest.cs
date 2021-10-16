using ECommercePlatform.Application.Wrapper;
using MediatR;

namespace ECommercePlatform.Application.DTOs.Requests
{
    public class CreateOrderRequest : IRequest<CommandResult>
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
    }
}
