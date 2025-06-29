using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Invoice:BaseEntity<int>
    {
        public DateTime Duration { get; set; }
        public decimal TotalAmount { get; set; }
        public ParkingRecord ParckingRecordId {  get; set; }
        public Payment payment { get; set; }
    }
}
