using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Presistence
{
    public class CPMSDbContext:DbContext
    {
        public CPMSDbContext(DbContextOptions<CPMSDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<VehicleOwner> vehicleOwners { get; set; }
        public DbSet<VehicleType> vehicleTypes { get; set; }
        public DbSet<Invoice> invoices { get; set; }
        public DbSet<Payment> payments { get; set; }
        public DbSet<Tariff> tariffs { get; set; }
        public DbSet<ParkingRecord> parkingRecords { get; set; }
        public DbSet<ParkingZone> parkingZones { get; set; }

    }
}
