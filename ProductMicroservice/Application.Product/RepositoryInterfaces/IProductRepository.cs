using Domain.Product.ProductModels;

namespace Application.Product.RepositoryInterfaces
{
    public interface IProductRepository
    {
        Task<ProductEntity?> GetProductByNameAsync(string productName);
        Task<ProductEntity?> GetProductByIdAsync(int id);
        Task<List<ProductEntity>> GetProductsForPageAsync(int page, int pageSize, string category);
        Task<ProductEntity> AddProductAsync(ProductEntity product);
    }
}
