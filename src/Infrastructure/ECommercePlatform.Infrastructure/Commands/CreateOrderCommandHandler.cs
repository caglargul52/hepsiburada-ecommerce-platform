using System;
using System.Threading;
using System.Threading.Tasks;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.Interfaces.Services;
using ECommercePlatform.Application.Wrapper;
using MediatR;

namespace ECommercePlatform.Infrastructure.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderRequest, CommandResult>
    {
        private readonly IOrderService _orderService;

        public CreateOrderCommandHandler(IOrderService orderService)
        {
            _orderService = orderService;
        }

        public async Task<CommandResult> Handle(CreateOrderRequest request, CancellationToken cancellationToken)
        {
            CommandResult commandResult = new CommandResult();

            try
            {
                var order = await _orderService.CreateOrder(request);

                commandResult.IsSuccess = true;
                commandResult.Message = order.ToString();
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
