using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPocket.Data.Entities;
using WebPocket.Repo.DbContexts;
using WebPocket.Repo.UnitOfWork;

namespace WebPocket.Repo.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseClass
    {
        private readonly DbContext _context;
        private DbSet<T> _entities;
        private string _errorMessage = string.Empty;

        public Repository(DbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }
        public async Task<T> GetAsync(int id)
        {
            return await _entities.SingleOrDefaultAsync(e => e.Id == id);
        }

        public T Insert(T entity)
        {
            if (entity == null) 
            {
                throw new ArgumentNullException("entity");
            }
            return _entities.Add(entity).Entity;
        }

        public T Update(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            return _entities.Update(entity).Entity;
        }

        public void Delete(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _entities.Remove(entity);
        }

        public void SaveChangesAsync()
        {
            _context.SaveChangesAsync();
        }
    }
}
