﻿using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IVehicleService
    {
        Task<PaginationResponse<VehicleDto>> GetAllVehiclesAsync(VehicleSpecificationParameter specvehicle);
        Task <VehicleDto?> GetVehicleByNumberAsync(string plateNumber);
        Task <IEnumerable<VehicleDto?>> GetVehicleOwnersAsync(string OwnerName);
        Task <IEnumerable<VehicleDto?>> GetAllVehicleBTypeAsync(string VehicleType); 
    }
}
