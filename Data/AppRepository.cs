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
        public void Update<T>(T entity) where T : class
        {
            foreach (var property in _context.Entry(entity).Properties)
            {
                if(property.CurrentValue != null && !property.Metadata.IsKey())
                    property.IsModified = true;
            }
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

        public async Task<bool> UserExistsById(int Id)
        {
            if(await _context.Users.AnyAsync(u => u.Id == Id))
            {
                return true;
            }
            return false;
        }
    }
}