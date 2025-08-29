using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IInvoiceServices
    {
        Task<InvoiceDto> GenerateInvoice(ParkingRecordDto record, TariffsDto tariff);
        Task<InvoiceDto?> GetInvoiceByIdAsync(int invoiceId);
       Task<PaginationResponse<InvoiceDto, InvoiceSpecificationParameter>> GetAllInvoicesAsync(InvoiceSpecificationParameter parameter);
    }
}
