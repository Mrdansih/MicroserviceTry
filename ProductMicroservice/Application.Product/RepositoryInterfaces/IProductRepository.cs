using Domain.Product.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
