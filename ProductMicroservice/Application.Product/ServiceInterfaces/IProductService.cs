using Domain.Product.ApiResponses;
using Domain.Product.ProductModels;

namespace Application.Product.ServiceInterfaces
{
    public interface IProductService
    {
        Task<ProductEntity?> GetProductByNameAsync(string? productName);
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<List<ProductDto>> GetProductsForPageAsync(int page, int pageSize, string category);
        Task<ProductEntity?> CreateProductsAsync(ProductDto request);
        Task<StockCheckResponse?> StockCheckAsync(int productId, int quantity);
    }
}
