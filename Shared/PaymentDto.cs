using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public string Method { get; set; }
        public DateTime PaidAt { get; set; }
        public int InvoiceId { get; set; }
        public string? ClientSecret { get; set; }
        public string? PaymentIntentId { get; set; }
        public decimal Price { get; set; }
    }
}
