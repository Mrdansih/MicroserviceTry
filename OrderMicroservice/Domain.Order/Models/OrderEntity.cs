namespace Domain.Order.Models
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? CustomerName { get; set; }
        public int Quantity { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
