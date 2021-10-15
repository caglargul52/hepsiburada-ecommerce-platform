using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities
{
    public class Order : BaseEntity
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
    }
}
