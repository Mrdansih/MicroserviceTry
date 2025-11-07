namespace Domain.Order.Models
{
    public class OrderDto
    {
        public int ProductId { get; set; }
        public string? CustomerName { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
