using Domain.Contracts;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence
{
    static class SpecificationEvaluation
    {
        public static IQueryable<TEntity>GetQuery<TEntity,TKey> 
            (IQueryable<TEntity>inpuyquery,ISpecification<TEntity,TKey>spec)
            where TEntity : BaseEntity<TKey>
        {
            var query= inpuyquery;
            if(spec.criterial is not null)
            {
                query = query.Where(spec.criterial);
                query = spec.Includes.Aggregate(query, (current, include) => current.Include(include));
            }
            if (spec.OrderBy is not null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            else if(spec.OrderByDescending is not null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }   
            if (spec.isPagingEnabled)
            {
                query = query.Skip(spec.skip).Take(spec.take);
            }
            return query;
        }
   }
}
