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
        Visa=2,
        paypal=3
    }
    public class Payment:BaseEntity<int>
    {
        public PaymentMethod Method { get; set; }
        public DateTime PaidAt { get; set; }
        public int InvoiceId { get; set; }
        public Invoice Invoice { get; set; }

        public string? ClientSecret { get; set; }
        public string? PaymentIntentId { get; set; }
        public decimal Price { get; set; }

    }
}
