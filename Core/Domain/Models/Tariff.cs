using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Tariff : BaseEntity<int>
    {
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; }
        public int ZoneId { get; set; }
        public ParkingZone Zone { get; set; }
        public decimal PricePerHour { get; set; }
    }

}
