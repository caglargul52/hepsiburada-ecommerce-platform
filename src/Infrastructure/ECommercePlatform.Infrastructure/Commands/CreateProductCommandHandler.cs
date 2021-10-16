using System;
using System.Threading;
using System.Threading.Tasks;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.Interfaces.Services;
using ECommercePlatform.Application.Wrapper;
using MediatR;

namespace ECommercePlatform.Infrastructure.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductRequest, CommandResult>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<CommandResult> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            CommandResult commandResult = new CommandResult();

            try
            {
                var product = await _productService.CreateProduct(request);

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
