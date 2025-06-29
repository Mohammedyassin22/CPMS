using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Data.Configurations
{
    public class InvoiceConfiguraiton : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.Property(x => x.TotalAmount).HasColumnType("decimal(7,3)");
            builder.HasOne(x=>x.ParckingRecord).WithOne(x=>x.invoice).OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x=>x.payment).WithOne(x=>x.Invoice).HasForeignKey<Payment>(x => x.InvoiceId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
