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
    public class VehicleConfiguration : IEntityTypeConfiguration<Vehicle>
    {
        public void Configure(EntityTypeBuilder<Vehicle> builder)
        {
            builder.HasOne(x=>x.OwnerId).WithMany(x=>x.Vehicles).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x=>x.ParkingRecords).WithOne(x=>x.Vehicle).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
