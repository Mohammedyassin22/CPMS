using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IVehicleService<TSpec,TDto>
    {
        Task<IEnumerable<TDto?>> GetAllVehicleBTypeAsync(string VehicleType);
        Task<PaginationResponse<TDto, TSpec>> GetAllVehiclesAsync(TSpec specvehicle);
        Task<TDto?> GetVehicleByNumberAsync(string plateNumber);
        Task<IEnumerable<TDto?>> GetVehicleOwnersAsync(string OwnerName);
    }
}
