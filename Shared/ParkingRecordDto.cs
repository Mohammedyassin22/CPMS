using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class ParkingRecordDto
    {
        public int Id { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime ExitTime { get; set; }
        public string ZoneName { get; set; }
        public int PlateNumber { get; set; }
        public int invoiceId { get; set; }
    }
}
