using Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class VehicleOwnerDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumuber { get; set; }
        public int PlateNumber { get; set; }
    }
}
