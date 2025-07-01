using Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class VehicleDto
    {
        public int Id { get; set; }
        public int PlateNumber { get; set; }
        public int VehicleType { get; set; }
        public string OwnerNAme { get; set; }

    }
}
