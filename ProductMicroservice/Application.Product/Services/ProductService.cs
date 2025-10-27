using Application.Product.RepositoryInterfaces;
using Application.Product.ServiceInterfaces;
using Domain.Product.ProductModels;

namespace Application.Product.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository repository)
        {
            this._productRepository = repository;
        }

        public async Task<ProductEntity?> GetProductByNameAsync(string? productName)
        {
            if (!String.IsNullOrEmpty(productName))
                return await _productRepository.GetProductByNameAsync(productName);

            return null;
        }

        public async Task<ProductEntity?> CreateProductsAsync(ProductDto request)
        {
            var product = new ProductEntity();

            var productExists = await GetProductByNameAsync(request.ProductName);

            if (productExists != null)
                return null;

            product.ProductName = request.ProductName;
            product.ProductDescription = request.ProductDescription;
            product.ProductCategory = request.ProductCategory;
            product.ProductPrice = request.ProductPrice;
            product.ProductQuantity = request.ProductQuantity;
            product.ProductImageUrl = request.ProductImageUrl;

            var createdProduct = await _productRepository.AddProductAsync(product);
            return createdProduct;
        }

        public async Task<ProductDto?> GetProductByIdAsync(int id)
        {
            var product = await _productRepository.GetProductByIdAsync(id);

            if (product == null)
                return null;

            return ProductMapper.ToDto(product);
        }

        public async Task<List<ProductDto>> GetProductsForPageAsync(int page, int pageSize, string category)
        {
            var products = await _productRepository.GetProductsForPageAsync(page, pageSize, category);
            return ProductMapper.ToDtoList(products);
        }
    }
}
