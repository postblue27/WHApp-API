using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WHApp_API.Models;

namespace WHApp_API.Interfaces
{
    public interface IAdminRepository
    {
        Task<List<User>> GetUsersByUserTypeAsync(string userTypeString);
        // Task<List<Renter>> GetRenters();
        // Task<List<Owner>> GetOwners();
        // Task<List<Driver>> GetDrivers();
        // Task<List<Admin>> GetAdmins();
        // Task<Owner> GetOwnerById(int Id);
        // Task<Renter> GetRenterById(int Id);
        // Task<Driver> GetDriverById(int Id);
        // Task<Admin> GetAdminById(int Id);
    }
}