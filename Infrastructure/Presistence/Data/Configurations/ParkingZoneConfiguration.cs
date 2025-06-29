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
    public class ParkingZoneConfiguration : IEntityTypeConfiguration<ParkingZone>
    {
        public void Configure(EntityTypeBuilder<ParkingZone> builder)
        {
            builder.HasMany(x=>x.tariffs).WithOne(x=>x.Zone).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x=>x.ParkingRecords).WithOne(x=>x.ZoneId).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
