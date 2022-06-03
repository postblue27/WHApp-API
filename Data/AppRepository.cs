using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WHApp_API.Interfaces;
using WHApp_API.Models;

namespace WHApp_API.Data
{
    public class AppRepository : IAppRepository
    {
        private readonly DataContext _context;
        public AppRepository(DataContext context)
        {
            _context = context;

        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        //TODO: Add check for nulls or consider using full model here.
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public async Task<T> GetByIdAsync<T>(int id) where T : class
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAsync<T>() where T : class
        {
            return await _context.Set<T>().ToListAsync();
        }
        public IEnumerable<T> Get<T>(Func<T, bool> predicate) where T : class
        {
            return _context.Set<T>().Where(predicate).ToList();
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0; // will return true if there is more than 0 changes
        }

        public async Task<bool> UserExistsById(int Id, string userType)
        {
            // switch(userType)
            // {
            //     case UserTypes.Renter:
            //         if(await _context.Renters.AnyAsync(u => u.Id == Id))
            //             return true;
            //             break;
            //     case UserTypes.Owner:
            //         if(await _context.Owners.AnyAsync(u => u.Id == Id))
            //             return true;
            //             break;
            //     case UserTypes.Driver:
            //         if(await _context.Drivers.AnyAsync(u => u.Id == Id))
            //             return true;
            //             break;
            //     case UserTypes.Admin:
            //         if(await _context.Admins.AnyAsync(u => u.Id == Id))
            //             return true;
            //             break;
            // }
            return false;
        }
    }
}