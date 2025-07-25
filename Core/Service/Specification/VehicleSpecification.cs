using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specification
{
    public class VehicleSpecification:BaseSpecification<Vehicle,int>
    {
        private void ApplyIncludes()
        {
            AddInclude(x => x.Owner);
            AddInclude(x => x.VehicleType);
        }
        public VehicleSpecification(string platnum)
     : base(x => x.PlateNumber == platnum)
        {
            ApplyIncludes();
        }
        public VehicleSpecification(VehicleSpecificationParameter specvehicle) :
         base(x => string.IsNullOrWhiteSpace(specvehicle.type) || x.VehicleType.TypeName == specvehicle.type)
        {
            ApplyIncludes();
           ApplySorting(specvehicle.sort);
           ApplyPaging(specvehicle.PageSize, specvehicle.IndexPage);
        }
        private void ApplySorting(string? sort)
        {
            if (!string.IsNullOrWhiteSpace(sort))
            {
                switch (sort.ToLower())
                {
                    case "typease":
                        AddOrderBy(x => x.VehicleType.TypeName);
                        break;
                    case "typedesc":
                        AddOrderByDesc(x => x.VehicleType.TypeName);
                        break;
                    default:
                        AddOrderBy(x => x.VehicleType.TypeName);
                        break;
                }
            }
            else
            {
                AddOrderBy(x => x.VehicleType.TypeName);
            }
     }   }
}
