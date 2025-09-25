using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IZoneServices
    {
        Task<PaginationResponse<ParkingZoneDto, ZoneSpecificationParameter>> GetAllZone(ZoneSpecificationParameter parameter);
        Task<ParkingZoneDto?> GetZoneByZone(string Zone);
    }
    public interface IParkingService
    {
        string Park(VehicleDto vehicle);
    }
}

