using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Specification
{
    public class RecordFindSpecfication : BaseSpecification<ParkingRecord, int>
    {
        public RecordFindSpecfication(string plateNumber)
            : base(r => r.Vehicle.PlateNumber == plateNumber && r.ExitTime == null)
        {
        }
    }
}
