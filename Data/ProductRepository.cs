using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WHApp_API.Interfaces;
using WHApp_API.Models;

namespace WHApp_API.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _context;
        public ProductRepository(DataContext context)
        {
            _context = context;
        }
        public async Task<Product> AddProduct(Product productToCreate)
        {
            Product newProduct = new Product(productToCreate);
            // return newProduct;
            await _context.Products.AddAsync(productToCreate);
            await _context.SaveChangesAsync();
            return newProduct;
        }

        public async Task<ProductInWarehouse> GetProduct(int productId)
        {
            var productInWarehouse = await _context.ProductsInWarehouse.Include(piw => piw.Product)
                .Include(piw => piw.Warehouse).Include(piw => piw.Zone).FirstOrDefaultAsync(piw => piw.ProductId == productId);

            return productInWarehouse;
        }
    }
}