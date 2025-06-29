using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public Collection<ParkingRecord> ParkingRecords { get; set; } 
        public Collection<Tariff> tariffs { get; set; } 
    }
}
