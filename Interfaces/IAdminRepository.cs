using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WHApp_API.Models;

namespace WHApp_API.Interfaces
{
    public interface IAdminRepository
    {
        IEnumerable<User> GetUsersByUserType(string userTypeString);
    }
}