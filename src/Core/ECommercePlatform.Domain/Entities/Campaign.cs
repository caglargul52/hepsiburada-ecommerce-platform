using System;
using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities
{
    public class Campaign : BaseEntity
    {
        public string Name { get; set; }
        public string ProductCode { get; set; }
        public int Duration { get; set; }
        public decimal ManipulationLimit { get; set; }
        public int TargetSalesCount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int RemainingTarget { get; set; }
    }
}
