using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specification
{
    public class VehicleCountSpecification:BaseSpecification<Vehicle,int>
    {
        public VehicleCountSpecification(VehicleSpecificationParameter specvehicle):
          base(x => (string.IsNullOrEmpty(specvehicle.search) || x.VehicleType.TypeName.ToLower().Contains(specvehicle.search.ToLower())) &&
            string.IsNullOrWhiteSpace(specvehicle.type) || x.VehicleType.TypeName == specvehicle.type)
        {

        }
    }
}
