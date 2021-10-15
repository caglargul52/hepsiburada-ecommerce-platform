using ECommercePlatform.Domain.Common;

namespace ECommercePlatform.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
    }
}
