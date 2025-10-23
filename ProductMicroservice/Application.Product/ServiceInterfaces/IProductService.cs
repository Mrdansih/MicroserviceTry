using Domain.Product.ProductModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Product.ServiceInterfaces
{
    public interface IProductService
    {
        Task<ProductEntity?> GetProductByNameAsync(string? productName);
        Task<ProductDto?> GetProductByIdAsync(int id);
        Task<List<ProductDto>> GetProductsForPageAsync(int page, int pageSize, string category);
        Task<ProductEntity?> CreateProductsAsync(ProductDto request);
    }
}
