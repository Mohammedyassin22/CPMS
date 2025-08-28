using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repository
{
    public class GenericRepository<TEntity, TKey>(CPMSDbContext dbContext) : IGenericRebository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public async Task AddAsync(TEntity entity)
        {
            await dbContext.AddAsync(entity);
        }

        public void Delete(TEntity entity)
        {
           dbContext.Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool trackchange = false)
        {
            if (trackchange)
            {
                return await dbContext.Set<TEntity>().ToListAsync();
            }
            return await dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
        }

        public void Update(TEntity entity)
        {
            dbContext.Update(entity);
        }

        public async Task<TEntity?> GetAsync(TKey Id)
        {
            return await dbContext.Set<TEntity>().FindAsync(Id);
        }

        public async Task<TEntity?> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await dbContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }


        
        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity, TKey> spec, bool trackchange = false)
        {
            return await ApplicationsException(spec).ToListAsync();
        }


        public async Task<TEntity?> GetAsync(ISpecification<TEntity, TKey> spec)
        {
            return await ApplicationsException(spec).FirstOrDefaultAsync();
        }


        public async Task<TEntity?> FindAsync(ISpecification<TEntity, TKey> spec)
        {
            return await ApplicationsException(spec).FirstOrDefaultAsync();
        }

        private IQueryable<TEntity> ApplicationsException(ISpecification<TEntity, TKey> spec)
        {
          return SpecificationEvaluation.GetQuery(dbContext.Set<TEntity>(), spec);
        }

        public async Task<int> CountAsync(ISpecification<TEntity, TKey> spec)
        {
            return await ApplicationsException(spec).CountAsync() ;
        }
    }
}
