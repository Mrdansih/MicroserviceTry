using Application.Product.RepositoryInterfaces;
using Domain.Product.ProductModels;
using Microsoft.EntityFrameworkCore;

namespace Persistence.Product.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ProductEntity?> GetProductByIdAsync(int id)
        {
            return await _context.Products.FindAsync(id);
        }

        public async Task<ProductEntity?> GetProductByNameAsync(string productName)
        {
            return await _context.Products.Where(p => p.ProductName == productName).FirstOrDefaultAsync();
        }

        public async Task<List<ProductEntity>> GetProductsForPageAsync(int page, int pageSize, string category)
        {
            var query = _context.Products.AsQueryable();

            if (!String.IsNullOrEmpty(category))
                query = query.Where(p => p.ProductCategory == category);

            return await query.OrderBy(p => p.Id).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<ProductEntity> AddProductAsync(ProductEntity product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return product;
        }

        public async Task UpdateProductQuantityAsync(ProductEntity product, int newQuantity)
        {
            product.ProductQuantity = newQuantity;
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }
    }
}
