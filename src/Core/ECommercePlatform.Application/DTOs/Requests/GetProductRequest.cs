using ECommercePlatform.Application.Wrapper;
using MediatR;

namespace ECommercePlatform.Application.DTOs.Requests
{
    public class GetProductRequest : IRequest<Result>
    {
        public string Code { get; set; }
    }
}
