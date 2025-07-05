using Domain.Contracts;
using Domain.Models;
using Presistence.Repository;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CPMSDbContext dbContext;

        private readonly ConcurrentDictionary<string, object> valuePairs = new();

        public UnitOfWork(CPMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IGenericRebository<TEntity, TKey> GetRebository<TEntity, TKey>()
            where TEntity : BaseEntity<TKey>
        {
            return (IGenericRebository<TEntity, TKey>)valuePairs.GetOrAdd(
                typeof(TEntity).Name,
                new GenericRepository<TEntity, TKey>(dbContext));
        }
        public async Task<int> SaveChangeAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
