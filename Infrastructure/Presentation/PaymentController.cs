using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PaymentController(IServiceManager serviceManager): ControllerBase
    {

        [HttpPost("{invoiceId}")]
        public async Task<IActionResult> CreateOrUpdatePaymentIntent(int invoiceId,  string paymentMethod)
        {
            var payment = await serviceManager.PaymentService.CreateOrUpdateIntentAsync(invoiceId, paymentMethod);
            return Ok(payment);
        }
    }
}
