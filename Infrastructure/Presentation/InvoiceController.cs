using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.ErrorDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class InvoiceController(IServiceManager serviceManager):ControllerBase
    {
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<InvoiceDto, InvoiceSpecificationParameter>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> GetGenerateInvoice(ParkingRecordDto record, TariffsDto tariff)
        {
            var result = await serviceManager.invoiceServices.GenerateInvoice(record,tariff);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<InvoiceDto, InvoiceSpecificationParameter>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> GetAllInvoicesAsync([FromQuery] InvoiceSpecificationParameter parameter)
        {
            var result = await serviceManager.invoiceServices.GetAllInvoicesAsync(parameter);
            return Ok(result);
        }

        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<InvoiceDto, InvoiceSpecificationParameter>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        public async Task<IActionResult> GetInvoiceByIdAsync(int invoiceId)
        {
            var result = await serviceManager.invoiceServices.GetInvoiceByIdAsync(invoiceId);
            if (result is null)
            {
                return NotFound();
            }
            return Ok(result);
        }
    }
}

