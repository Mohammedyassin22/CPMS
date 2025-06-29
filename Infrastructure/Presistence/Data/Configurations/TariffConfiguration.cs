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
    public class TariffConfiguration : IEntityTypeConfiguration<Tariff>
    {
        public void Configure(EntityTypeBuilder<Tariff> builder)
        {
            builder.Property(x => x.PricePerHour).HasColumnType("decimal(10,3)");
            builder.HasOne(t => t.VehicleType)
         .WithMany(x => x.tariffs);

        }
    }
}
