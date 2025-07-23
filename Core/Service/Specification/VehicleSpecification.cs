using Domain.Models;
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
        public VehicleSpecification(string platnum) : base(x=>x.PlateNumber==platnum)
        {
            ApplyIncludes();
        }
        public VehicleSpecification() : base(null)
        {
            ApplyIncludes();
        }
    }
}
