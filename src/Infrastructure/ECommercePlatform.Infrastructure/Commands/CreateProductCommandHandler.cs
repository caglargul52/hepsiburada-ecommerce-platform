using System;
using System.Threading;
using System.Threading.Tasks;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.Interfaces.Services;
using ECommercePlatform.Application.Wrapper;
using MediatR;

namespace ECommercePlatform.Infrastructure.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductRequest, Result>
    {
        private readonly IProductService _productService;

        public CreateProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }

        public async Task<Result> Handle(CreateProductRequest request, CancellationToken cancellationToken)
        {
            Result result = new Result();

            try
            {
                var product = await _productService.CreateProduct(request);

                result.IsSuccess = true;
                result.Message = product.ToString();
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Message = e.Message;
            }

            return result;
        }
    }
}
