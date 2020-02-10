using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebPocket.Data.Entities;
using WebPocket.Repo.DbContexts;
using WebPocket.Repo.Repositories;

namespace WebPocket.Repo.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly AppDbContext _context;
        private string _errorMessage = string.Empty;
        private IDbContextTransaction _transaction;
        private Dictionary<string, object> _repositories = new Dictionary<string, object>();

        public UnitOfWork()
        {
            _context = new AppDbContext();
        }

        public AppDbContext Context => _context;

        public Repository<TEntity> Repository<TEntity>() where TEntity : BaseClass
        {
            string typeName = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(typeName))
            {
                _repositories.Add(typeName, new Repository<TEntity>(Context));
            }

            return _repositories[typeName] as Repository<TEntity>;
        }

        public async Task CreateTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            await _transaction.CommitAsync();
        }

        public async Task RollbackAsync()
        {
            await _transaction.RollbackAsync();
            Dispose();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        #region IDisposable Support

        private bool _disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                _disposed = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
