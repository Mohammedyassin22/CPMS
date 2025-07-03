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
        public string PlateNumber { get; set; }     
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
        public int OwnerId { get; set; }
        public VehicleOwner Owner { get; set; }     
        public Collection<ParkingRecord> ParkingRecords { get; set; }
    }

}
