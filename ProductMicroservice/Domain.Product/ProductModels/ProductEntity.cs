namespace Domain.Product.ProductModels
{
    public class ProductEntity
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? ProductDescription { get; set; }
        public string? ProductCategory { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public string? ProductImageUrl { get; set; }
    }
}
