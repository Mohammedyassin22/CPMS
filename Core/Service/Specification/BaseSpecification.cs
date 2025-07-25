using Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specification
{
    public class BaseSpecification<TEntity, Tkey> : ISpecification<TEntity, Tkey> where TEntity : Domain.Models.BaseEntity<Tkey>
    {
        public Expression<Func<TEntity, bool>>? criterial { get; set; }
        public List<Expression<Func<TEntity, object>>> Includes { get;  set; }=new List<Expression<Func<TEntity, object>>>();
        public BaseSpecification(Expression<Func<TEntity, bool>>? expression)
        {
            criterial = expression;
        }
        public void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        public Expression<Func<TEntity, object>>? OrderBy { get ; set ; }
        public Expression<Func<TEntity, object>>? OrderByDescending { get; set; }
        protected void AddOrderBy(Expression<Func<TEntity, object>> expression)
        {
            OrderBy= expression;
        }
        protected void AddOrderByDesc(Expression<Func<TEntity, object>> includeExpression)
        {
            OrderByDescending=includeExpression;
        }

        public int skip { get ; set; }
        public int take { get ; set; }
        public bool isPagingEnabled { get; set ; }
        protected void ApplyPaging(int pageindex, int pagesize)
        {
            isPagingEnabled = true;
            take = pagesize;
            skip = (pageindex - 1) * pagesize;
        }
    }
}
