using System.Collections.Generic;
using System.Linq;
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
            await _context.Products.AddAsync(productToCreate);
            await _context.SaveChangesAsync();
            return newProduct;
        }

        public async Task<List<ProductInWarehouse>> GetProductsInWarehouse(int warehouseId)
        {
            var piwList = await _context.ProductsInWarehouse.Where(w => w.WarehouseId == warehouseId).ToListAsync();
            
            return piwList;
        }
        public async Task<bool> ProductInWarehouseExists(int piwId)
        {
            if(await _context.ProductsInWarehouse.AnyAsync(piw => piw.Id == piwId))
                return true;
            return false;
        }
    }
}