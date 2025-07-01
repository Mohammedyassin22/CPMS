using Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ParkingZoneDto
    {
        public int Id { get; set; }
        public string ZomeNAme { get; set; }
        public int Capacity { get; set; }
        public string LocationDescription { get; set; }
    }
}
