using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class TariffsDto
    {
        public int Id { get; set; }
        public string VehicleType { get; set; }
        public string Zone { get; set; }
        public decimal PricePerHour { get; set; }
    }
}
