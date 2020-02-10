using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebPocket.Data.Entities;
using WebPocket.Repo.DbContexts;
using WebPocket.Repo.Repositories;

namespace WebPocket.Repo.UnitOfWork
{
    public interface IUnitOfWork
    {
        AppDbContext Context { get; }

        Repository<TEntity> Repository<TEntity>() where TEntity : BaseClass;
        Task CreateTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task SaveChangesAsync();
    }
}
