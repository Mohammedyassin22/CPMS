using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class VehicleType:BaseEntity<int>
    {
        public IEnumerable<VehicleOwner> vehicles { get; set; }=Enumerable.Empty<VehicleOwner>();
        public IEnumerable<Tariff> tariffs { get; set; } = Enumerable.Empty<Tariff>();
        public string TypeName { get; set; }
    }
}
