using AutoMapper;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models;
using Microsoft.Extensions.Configuration;
using ServiceAbstraction;
using Shared;
using Stripe;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using paymentMethod = Domain.Models.PaymentMethod;
using PaymentMethod = Domain.Models.PaymentMethod;

namespace Service
{
    public class PaymentServices(IUnitOfWork unitOfWork,IMapper mapper,IConfiguration configuration) : IPamentServices
    {
        public async Task<PaymentDto> CreateOrUpdateIntentAsync(int invoiceId, string paymentMethods)
        {
            var invoice = await unitOfWork.GetRebository<Domain.Models.Invoice, int>().GetAsync(invoiceId);
            if (invoice == null)
                throw new InvoiceNotFoundException(invoiceId);

            var amount = invoice.TotalAmount;

            if (!Enum.TryParse<PaymentMethod>(paymentMethods, true, out var paymentMethodValue))
                throw new ArgumentException("Invalid payment method");
            StripeConfiguration.ApiKey = configuration["Stripe:SecretKey"];
            var stripe = new PaymentIntentService();

            var paymentType = paymentMethodValue switch
            {
                PaymentMethod.Cash => "card",
                PaymentMethod.Visa => "paypal",
                _ => throw new ArgumentException("Unsupported payment method")
            };

            if (invoice.payment == null || string.IsNullOrEmpty(invoice.payment.PaymentIntentId))
            {
                var options = new PaymentIntentCreateOptions
                {
                    Amount = (long)(amount * 100),
                    Currency = "usd",
                    PaymentMethodTypes = new List<string> { paymentType }
                };

                var intent = await stripe.CreateAsync(options);

                invoice.payment = new Payment
                {
                    InvoiceId = invoice.Id,
                    Method = paymentMethodValue,
                    PaidAt = DateTime.UtcNow,
                    Price = amount,
                    ClientSecret = intent.ClientSecret,
                    PaymentIntentId = intent.Id
                };
            }
            else
            {
                var options = new PaymentIntentUpdateOptions
                {
                    Amount = (long)(amount * 100)
                };

                await stripe.UpdateAsync(invoice.payment.PaymentIntentId, options);

                invoice.payment.Price = amount;
                invoice.payment.Method = paymentMethodValue;
                invoice.payment.PaidAt = DateTime.UtcNow;
            }

            await unitOfWork.SaveChangeAsync();
            return mapper.Map<PaymentDto>(invoice.payment);
        }
    }
}
