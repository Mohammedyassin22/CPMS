using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ParkingRecord:BaseEntity<int>
    {
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public ParkingZone ZoneId { get; set; }

        public int VehicleId { get; set; }         
        public Vehicle Vehicle { get; set; }    
        public Invoice invoice { get; set; }
    }
}
