using System.Collections.Generic;
using System.Threading.Tasks;
using WHApp_API.Models;

namespace WHApp_API.Interfaces
{
    public interface IAdminRepository
    {
        Task<List<Owner>> GetOwners();
    }
}