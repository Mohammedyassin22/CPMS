using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IGenericRebository<TEntity,TKey>where TEntity:BaseEntity<TKey>
    {
        Task<TEntity?> GetAsync(TKey Id);
        Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetAllAsync(bool trackchange = false);

        Task<TEntity?> GetAsync(ISpecification<TEntity,TKey>spec); 
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecification<TEntity, TKey> spec,bool trackchange = false);
        Task<TEntity?> FindAsync(ISpecification<TEntity, TKey> spec);

        Task AddAsync(TEntity entity);
        void Update (TEntity entity);
        void Delete (TEntity entity);

        Task<int>CountAsync(ISpecification<TEntity, TKey> spec);
    }
}
