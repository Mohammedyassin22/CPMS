using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IGenericRebository<TEntity,TKey>where TEntity:BaseEntity<TKey>
    {
        Task<TEntity?> GetAsync(TKey Id);
        Task<IEnumerable<TEntity>> GetAllAsync(bool trackchange = false);
        Task AddAsync(TEntity entity);
        void Update (TEntity entity);
        void Delete (TEntity entity);
    }
}
