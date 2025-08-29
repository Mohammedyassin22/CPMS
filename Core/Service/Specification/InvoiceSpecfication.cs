using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specification
{
    public class InvoiceSpecfication:BaseSpecification<Invoice,int>
    {

        public InvoiceSpecfication(int id) : base(x => x.Id == id)
        {
            ApplySorting(null); // default sorting
        }

        public InvoiceSpecfication(InvoiceSpecificationParameter specZone)
         : base(x =>
             (string.IsNullOrEmpty(specZone.search) ||
              x.Id.ToString() == specZone.search) &&  
             (specZone.Id == 0 || x.Id == specZone.Id)
         )
        {
            ApplySorting(specZone.sort);
            ApplyPaging(specZone.PageSize, specZone.IndexPage);
        }
        private void ApplySorting(string? sort)
        {
            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort.ToLower())
                {
                    case "asc":
                        AddOrderBy(x => x.Id);
                        break;
                    case "desc":
                        AddOrderByDesc(x => x.Id);
                        break;
                    default:
                        AddOrderBy(x => x.Id);
                        break;
                }
            }
            else
            {
                AddOrderBy(x => x.Id);
            }
        }
    }
}
