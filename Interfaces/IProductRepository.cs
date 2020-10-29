using System.Threading.Tasks;
using WHApp_API.Models;

namespace WHApp_API.Interfaces
{
    public interface IProductRepository
    {
    //     Task<Product> AddProduct(string ProductName, string Description,
    //             string ProductCode, int Volume, int UserId);
        Task<Product> AddProduct(Product product);
        Task<ProductInWarehouse> GetProduct(int productId);
        
    }
}