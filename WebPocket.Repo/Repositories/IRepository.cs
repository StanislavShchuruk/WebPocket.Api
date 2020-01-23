using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using WebPocket.Data.Entities;

namespace WebPocket.Repo.Repositories
{
    public interface IRepository<T> where T : BaseClass
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);

        void SaveChangesAsync();
    }
}
