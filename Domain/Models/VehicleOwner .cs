using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class VehicleOwner:BaseEntity<int>
    {
        public string FullName { get; set; }
        public string PhoneNumuber { get; set; }
        public IEnumerable<Vehicle> Vehicles { get; set; }
    }
}
