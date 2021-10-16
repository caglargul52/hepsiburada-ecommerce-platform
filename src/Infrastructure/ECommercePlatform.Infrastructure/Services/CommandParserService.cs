using System;
using System.Linq;
using ECommercePlatform.Application.DTOs.Requests;
using ECommercePlatform.Application.Interfaces.Services;
using ECommercePlatform.Application.Wrapper;
using MediatR;

namespace ECommercePlatform.Infrastructure.Services
{
    public class CommandParserService : ICommandParserService
    {
        public IRequest<Result> ConvertCommand(string command)
        {
            if (string.IsNullOrEmpty(command)) return null;

            var splittedCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var prefixCommand = splittedCommand.FirstOrDefault();

            return prefixCommand switch
            {
                "create_product" => PrepareCreateProductDto(splittedCommand),
                "get_product_info" => PrepareGetProductDto(splittedCommand),
                "create_campaign" => PrepareCreateCampaignDto(splittedCommand),
                "get_campaign_info" => PrepareGetCampaignDto(splittedCommand),
                "create_order" => PrepareCreateOrderDto(splittedCommand),
                "increase_time" => PrepareTimeIncrease(splittedCommand),
                _ => null
            };
        }

        private IRequest<Result> PrepareCreateProductDto(string[] splittedCommand)
        {
            try
            {
                return new CreateProductRequest
                {
                    Code = splittedCommand[1],
                    Price = Convert.ToDecimal(splittedCommand[2]),
                    Stock = Convert.ToInt32(splittedCommand[3])
                };
            }
            catch
            {
                return null;
            }
        }

        private IRequest<Result> PrepareCreateCampaignDto(string[] splittedCommand)
        {
            try
            {
                return new CreateCampaignRequest
                {
                    Name = splittedCommand[1],
                    ProductCode = splittedCommand[2],
                    Duration = Convert.ToInt32(splittedCommand[3]),
                    ManipulationLimit = Convert.ToDecimal(splittedCommand[4]),
                    TargetSalesCount = Convert.ToInt32(splittedCommand[5])
                };
            }
            catch
            {
                return null;
            }
        }

        private IRequest<Result> PrepareCreateOrderDto(string[] splittedCommand)
        {
            try
            {
                return new CreateOrderRequest
                {
                    ProductCode = splittedCommand[1],
                    Quantity = Convert.ToInt32(splittedCommand[2])
                };
            }
            catch
            {
                return null;
            }
        }

        private IRequest<Result> PrepareGetProductDto(string[] splittedCommand)
        {
            try
            {
                return new GetProductRequest
                {
                    Code = splittedCommand[1]
                };
            }
            catch
            {
                return null;
            }
        }

        private IRequest<Result> PrepareGetCampaignDto(string[] splittedCommand)
        {
            try
            {
                return new GetCampaignRequest
                {
                    Name = splittedCommand[1]
                };
            }
            catch
            {
                return null;
            }
        }

        private IRequest<Result> PrepareTimeIncrease(string[] splittedCommand)
        {
            try
            {
                return new IncreaseTimeRequest
                {
                    Hour = Convert.ToInt32(splittedCommand[1])
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
