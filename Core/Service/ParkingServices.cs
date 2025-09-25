using Domain.Exceptions;
using ServiceAbstraction;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ParkingService : IParkingService
    {
        private readonly List<VehicleDto> _parkedVehicles = new();

        public string Park(VehicleDto vehicle)
        {
            if (string.IsNullOrWhiteSpace(vehicle.PlateNumber))
                return MultiMessageParkingServicesException.message1;

            if (_parkedVehicles.Any(v => v.PlateNumber == vehicle.PlateNumber))
                return MultiMessageParkingServicesException.message2;

            _parkedVehicles.Add(vehicle);
            return MultiMessageParkingServicesException.message3;
        }
    }
}
