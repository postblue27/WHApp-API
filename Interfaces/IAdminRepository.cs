using System.Collections.Generic;
using System.Threading.Tasks;
using WHApp_API.Models;

namespace WHApp_API.Interfaces
{
    public interface IAdminRepository
    {
        Task<List<Renter>> GetRenters();
        Task<List<Owner>> GetOwners();
        Task<List<Driver>> GetDrivers();
        Task<List<Admin>> GetAdmins();
        Task<Owner> GetOwnerById(int userId);
        Task<Renter> GetRenterById(int userId);
        Task<Driver> GetDriverById(int userId);
        Task<Admin> GetAdminById(int userId);
    }
}