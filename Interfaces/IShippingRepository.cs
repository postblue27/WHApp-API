using System.Collections.Generic;
using System.Threading.Tasks;
using WHApp_API.Models;

namespace WHApp_API.Interfaces
{
    public interface IShippingRepository
    {
        Task<bool> CarExists(int carCode);
        Task<List<Car>> GetCars();
    }
}