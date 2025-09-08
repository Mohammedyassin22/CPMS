using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IPamentServices
    {
        Task<PaymentDto> CreateOrUpdateIntentAsync(int invoiceId,string paymentMethod);
    }
}
