using System.Collections.Generic;
using System.Threading.Tasks;
using WHApp_API.Models;

namespace WHApp_API.Interfaces
{
    public interface IAppRepository
    {
        void Add<T>(T entity) where T: class;
        void Delete<T>(T entity) where T: class;
        Task<bool> SaveAll();
        Task<List<Warehouse>> GetWarehouses();
    }
}