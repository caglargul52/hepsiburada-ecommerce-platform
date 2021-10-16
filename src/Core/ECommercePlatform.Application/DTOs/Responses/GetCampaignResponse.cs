namespace ECommercePlatform.Application.DTOs.Responses
{
    public class GetCampaignResponse
    {
        public string Name { get; set; }
        public bool IsActive { get; set; }
        public int TargetSalesCount { get; set; }
        public int TotalSalesCount { get; set; }
        public decimal AvarageItemPrice { get; set; }
        public decimal TurnOver { get; set; }

        public override string ToString()
        {
            var campaignStatus = IsActive ? "Active" : "Ended";

            return $"Campaign {Name} info; Status {campaignStatus}, Target Sales {TargetSalesCount}, Total Sales {TotalSalesCount} Turnover {TurnOver}, Average Item Price {AvarageItemPrice}";
        }
    }
}
