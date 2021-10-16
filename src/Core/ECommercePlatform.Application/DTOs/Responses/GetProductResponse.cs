namespace ECommercePlatform.Application.DTOs.Responses
{
    public class GetProductResponse
    {
        public string Code { get; set; }
        public decimal CampaignPrice { get; set; }
        public int Stock { get; set; }

        public override string ToString()
        {
            return $"Product {Code} info: price {CampaignPrice} stock {Stock}";
        }
    }
}
