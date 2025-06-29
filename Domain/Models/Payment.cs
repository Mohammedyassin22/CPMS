using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public enum PaymentMethod
    {
        Cash=1,
        Visa=2
    }
    public class Payment:BaseEntity<int>
    {
        public PaymentMethod Method { get; set; }
        public DateTime PaidAt { get; set; }
        public int Invoice { get; set; }
        public Invoice InvoiceId { get; set; }
    }
}
