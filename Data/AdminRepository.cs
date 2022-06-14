using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WHApp_API.Interfaces;
using WHApp_API.Models;

namespace WHApp_API.Data
{
    public class AdminRepository : IAdminRepository
    {
        private readonly DataContext _context;
        private readonly IAppRepository _apprepo;
        public AdminRepository(DataContext context, IAppRepository apprepo)
        {
            _context = context;
            _apprepo = apprepo;

        }
        public virtual IEnumerable<User> GetUsersByUserType(string userTypeString)
        {
            return _apprepo.Get<User>(u => u.UserType == userTypeString);
        }
    }
}