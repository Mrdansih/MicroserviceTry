using Domain.Product.ProductModels;

namespace Application.Product
{
    internal class ProductMapper
    {
        public static List<ProductDto> ToDtoList(List<ProductEntity> products)
        {
            return products.Select(ToDto).ToList();
        }

        public static ProductDto ToDto(ProductEntity product)
        {
            return new ProductDto
            {
                ProductName = product.ProductName,
                ProductDescription = product.ProductDescription,
                ProductCategory = product.ProductCategory,
                ProductPrice = product.ProductPrice,
                ProductQuantity = product.ProductQuantity,
                ProductImageUrl = product.ProductImageUrl
            };
        }
    }
}
