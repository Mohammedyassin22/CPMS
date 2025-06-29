using Domain;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence
{
    public class DbIntilaizer(CPMSDbContext dbContext) : IDbIntilaizer
    {
        public async Task IntilaizerAsync()
        {
            if (dbContext.Database.GetPendingMigrations().Any())
            {
                await dbContext.Database.MigrateAsync();
            }

            if (!dbContext.vehicleTypes.Any())
            {
                dbContext.vehicleTypes.AddRange(
                    new VehicleType { TypeName = "Car" },
                    new VehicleType { TypeName = "Truck" },
                    new VehicleType { TypeName = "Bike" }
                );
               
            }

            if (!dbContext.parkingZones.Any())
            {
                dbContext.parkingZones.AddRange(
                    new ParkingZone { ZomeNAme = "Zone A", LocationDescription = "Near Entrance A", Capacity = 50 },
                    new ParkingZone { ZomeNAme = "Zone B", LocationDescription = "Near Entrance B", Capacity = 30 }
                );
                await dbContext.SaveChangesAsync();
            }

            if (!dbContext.tariffs.Any())
            {
                var car = await dbContext.vehicleTypes.FirstOrDefaultAsync(x => x.TypeName == "Car");
                var truck = await dbContext.vehicleTypes.FirstOrDefaultAsync(x => x.TypeName == "Truck");
                var bike = await dbContext.vehicleTypes.FirstOrDefaultAsync(x => x.TypeName == "Bike");

                var zoneA = await dbContext.parkingZones.FirstOrDefaultAsync(x => x.ZomeNAme == "Zone A");
                var zoneB = await dbContext.parkingZones.FirstOrDefaultAsync(x => x.ZomeNAme == "Zone B");

                dbContext.tariffs.AddRange(
                    new Tariff { VehicleTypeId = car.Id, ZoneId = zoneA.Id, PricePerHour = 10 },
                    new Tariff { VehicleTypeId = truck.Id, ZoneId = zoneA.Id, PricePerHour = 20 },
                    new Tariff { VehicleTypeId = bike.Id, ZoneId = zoneA.Id, PricePerHour = 5 },
                    new Tariff { VehicleTypeId = car.Id, ZoneId = zoneB.Id, PricePerHour = 8 },
                    new Tariff { VehicleTypeId = bike.Id, ZoneId = zoneB.Id, PricePerHour = 15 },
                    new Tariff { VehicleTypeId = truck.Id, ZoneId = zoneB.Id, PricePerHour = 25 }
                );

                await dbContext.SaveChangesAsync();
            }
        }

    }

}
