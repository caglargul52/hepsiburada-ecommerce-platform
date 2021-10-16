namespace ECommercePlatform.Application.DTOs.Responses
{
    public class CreateOrderResponse
    {
        public string ProductCode { get; set; }
        public int Quantity { get; set; }

        public override string ToString()
        {
            return $"Order created; product {ProductCode}, quantity {Quantity}";
        }
    }
}
