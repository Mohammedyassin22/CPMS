using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public Collection<ParkingRecord> ParkingRecords { get; set; }
    }
}
