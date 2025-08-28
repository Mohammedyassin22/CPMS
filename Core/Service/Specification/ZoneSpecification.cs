using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specification
{
    public class ZoneSpecification:BaseSpecification<ParkingZone,int>
    {
        private void ApplyIncludes()
        {
            AddInclude(x => x.Capacity);
        }
        public ZoneSpecification(string zone) : base(x => x.ZomeNAme == zone)
        {
            ApplyIncludes(); }
        public ZoneSpecification(ZoneSpecificationParameter specZone)
       : base(x =>
           (string.IsNullOrEmpty(specZone.search) ||
         x.ZomeNAme.ToLower().Contains(specZone.search.ToLower())) &&
        (string.IsNullOrWhiteSpace(specZone.zone) ||
         x.ZomeNAme == specZone.zone)
       )
        {
            ApplyIncludes();
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
                        AddOrderBy(x => x.ZomeNAme);
                        break;
                    case "desc":
                        AddOrderByDesc(x => x.ZomeNAme);
                        break;
                    default:
                        AddOrderBy(x => x.ZomeNAme);
                        break;
                }
            }
            else
            {
                AddOrderBy(x => x.ZomeNAme);
            }
        }



    }
}
