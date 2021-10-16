using ECommercePlatform.Application.Wrapper;
using MediatR;

namespace ECommercePlatform.Application.Interfaces.Services
{
    public interface ICommandParserService
    {
        IRequest<Result> ConvertCommand(string command);
    }
}
