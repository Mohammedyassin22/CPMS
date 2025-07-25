using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface ISpecification<TENtity,TKey> where TENtity : BaseEntity<TKey>
    {
        Expression<Func<TENtity,bool>>criterial { get; set; }
        List<Expression<Func<TENtity, object>>> Includes { get; set; }
        Expression<Func<TENtity, object>>? OrderBy { get; set; } 
        Expression<Func<TENtity, object>>? OrderByDescending { get; set; }
         int skip { get; set; }
        int take { get; set; }
        bool isPagingEnabled { get; set; }
    }
}
