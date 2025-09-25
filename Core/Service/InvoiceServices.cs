using AutoMapper;
using Domain.Contracts;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceAbstraction;
using Domain.Models;
using Service.Specification;

namespace Service
{
    public class InvoiceServices(IUnitOfWork unitOfWork, IMapper mapper) : IInvoiceServices
    {
        public async Task<InvoiceDto> GenerateInvoice(ParkingRecordDto record, TariffsDto tariff)
        {
            var duration = record.ExitTime - record.EntryTime;
            var totalHours = Math.Ceiling(duration.TotalHours);
            var totalAmount = (decimal)totalHours * tariff.PricePerHour;

            var invoice = new Invoice
            {
                Duration = duration,
                TotalAmount = totalAmount,
                ParckingRecord = mapper.Map<ParkingRecord>(record),
                payment = new Payment
                {
                    Method = PaymentMethod.Cash,
                    PaidAt = DateTime.Now
                }
            };

            var invoiceDto = mapper.Map<InvoiceDto>(invoice);
            return invoiceDto;
        }

        public async Task<PaginationResponse<InvoiceDto, InvoiceSpecificationParameter>> GetAllInvoicesAsync(InvoiceSpecificationParameter parameter)
        {
            var spec = new InvoiceSpecfication(parameter);

            var count = await unitOfWork.GetRebository<Invoice, int>().CountAsync(spec);
            var invoices = await unitOfWork.GetRebository<Invoice, int>().GetAllAsync(spec);

            var result = mapper.Map<IEnumerable<InvoiceDto>>(invoices);
            return new PaginationResponse<InvoiceDto, InvoiceSpecificationParameter>(
                parameter,
                parameter.IndexPage,
                parameter.PageSize,
                count,
                result
            );
        }

        public async Task<InvoiceDto?> GetInvoiceByIdAsync(int invoiceId)
        {
            var spec = new InvoiceSpecfication(invoiceId);
            var vehicle = await unitOfWork.GetRebository<Invoice, int>().FindAsync(spec);
            if (vehicle is null)
            {
                return null;
            }
            var result = mapper.Map<InvoiceDto>(vehicle);
            return result;
        }
    }
}
