using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class ParkingZone:BaseEntity<int>
    {
        public string ZomeNAme { get; set; }
        public int Capacity { get; set; }
        public string LocationDescription { get; set; }
        public IEnumerable<ParkingRecord> ParkingRecords { get; set; } = Enumerable.Empty<ParkingRecord>();
        public IEnumerable<Tariff> tariffs { get; set; } = Enumerable.Empty<Tariff>();
    }
}
