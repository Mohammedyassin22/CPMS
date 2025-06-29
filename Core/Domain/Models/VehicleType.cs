using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class VehicleType:BaseEntity<int>
    {
        public Collection<VehicleOwner> vehicles { get; set; }
        public Collection<Tariff> tariffs { get; set; }
        public string TypeName { get; set; }
    }
}
