using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public DateTime Duration { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime ParckingRecord { get; set; }
        public decimal payment { get; set; }
    }
}
