namespace ECommercePlatform.Application.DTOs.Responses
{
    public class CreateCampaignResponse
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public decimal ManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }

        public override string ToString()
        {
            return $"Campaign created; name {Name}, product {ProductCode}, duration {Duration}, limit {ManipulationLimit}, target sales count {TargetSalesCount}";
        }
    }
}