using Microsoft.EntityFrameworkCore;
using PhoneStoreBackend.Data;
using PhoneStoreBackend.Models;

namespace PhoneStoreBackend.Repositories
{
    public class ProductRepository
    {
        private ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            return await _context.Products.ToListAsync();
        }
        
        public async Task<Product> GetProductById(int id)
        {
            using (_context)
            {
                return await _context.Products.FirstOrDefaultAsync(x => x.PhoneID == id);
            }
        }

        public async Task AddProduct(Product product)
        {
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteProduct(Product product)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}
