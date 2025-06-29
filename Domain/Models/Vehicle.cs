using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Vehicle : BaseEntity<int>
    {
        public int PlateNumber { get; set; }
        public int VehicleType { get; set; }
        public VehicleOwner OwnerId { get; set; }
        public IEnumerable<ParkingRecord> ParkingRecords { get; set; } = Enumerable.Empty<ParkingRecord>();
    }
}
