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
    public class UnitOfWork(CPMSDbContext dbContext,ConcurrentDictionary<string,object> valuePairs) : IUnitOfWork
    {
        public  IGenericRebository<TEntity, TKey> GetRebository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
        => (IGenericRebository<TEntity, TKey>)valuePairs.GetOrAdd(typeof(TEntity).Name, new GenericRepository<TEntity, TKey>(dbContext));

        public async Task<int> SaveChangeAsync()
        {
            return await dbContext.SaveChangesAsync();
        }
    }
}
