using dijitalu.ModelLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace BulkSenderAPI.Data
{

    public interface IUnitOfWork : IDisposable
    {
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : BaseEntity;
        int SaveChanges();
        Task<int> SaveChangesAsync();
    }

    public interface IUnitOfWork<TContext> : IUnitOfWork where TContext : DbContext
    {
         TContext Context { get; }
    }
}
