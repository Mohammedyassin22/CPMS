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
        public int ParckingRecordId { get; set; }
        public ParkingRecord ParckingRecord {  get; set; }
        public Payment payment { get; set; }
    }
}
