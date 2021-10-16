namespace ECommercePlatform.Application.DTOs.Responses
{
    public class CreateProductResponse
    {
        public string Code { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }

        public override string ToString()
        {
            return $"Product created; code {Code}, price {Price}, stock {Stock}";
        }
    }
}
