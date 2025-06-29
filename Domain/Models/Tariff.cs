using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Tariff:BaseEntity<int>
    {
        public int VehicleType { get; set; }
        public VehicleType VehicleTypes { get; set; }
        public decimal PricePerHour { get; set;}
        public int Zone { get; set; }
        public ParkingZone ZoneId {  get; set; } 
    }
}
