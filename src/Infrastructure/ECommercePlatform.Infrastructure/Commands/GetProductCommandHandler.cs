using System;
using System.Threading;
using System.Threading.Tasks;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.Interfaces.Services;
using ECommercePlatform.Application.Wrapper;
using MediatR;

namespace ECommercePlatform.Infrastructure.Commands
{
    public class GetProductCommandHandler : IRequestHandler<GetProductRequest, CommandResult>
    {
        private readonly IProductService _productService;

        public GetProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<CommandResult> Handle(GetProductRequest request, CancellationToken cancellationToken)
        {
            CommandResult commandResult = new CommandResult();

            try
            {
                var product = await _productService.GetProductAsync(request);

                commandResult.IsSuccess = true;
                commandResult.Message = product.ToString();
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
