using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using ServiceAbstraction;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class VehicleService(IUnitOfWork unitOfWork, IMapper mapper) : IVehicleService
    {
        public async Task<IEnumerable<VehicleDto?>> GetAllVehicleBTypeAsync(string VehicleType)
        {
            var type = await unitOfWork.GetRebository<Vehicle, int>().FindAsync(x => x.VehicleType.TypeName == VehicleType);
            var result = mapper.Map<IEnumerable<VehicleDto>>(type);
            return result;
        }

        public async Task<IEnumerable<VehicleDto>> GetAllVehiclesAsync()
        {
            var vehicles = await unitOfWork.GetRebository<Vehicle, int>().GetAllAsync();
            var result=mapper.Map<IEnumerable<VehicleDto>>(vehicles);
            return result;
        }

        public async Task<VehicleDto?> GetVehicleByNumberAsync(string plateNumber)
        {
            var vehicle = await unitOfWork.GetRebository<Vehicle, int>().FindAsync(x=>x.PlateNumber==plateNumber);
            if(vehicle is null)
            {
                   return null;
            }
            var result = mapper.Map<VehicleDto>(vehicle);
            return result;
        }

        public async Task<IEnumerable<VehicleDto?>> GetVehicleOwnersAsync(string OwnerName)
        {
           var owner = await unitOfWork.GetRebository<Vehicle,int>().FindAsync(x=>x.Owner.FullName == OwnerName);
            var result = mapper.Map<IEnumerable<VehicleDto>>(owner);
            return result;
        }

    }
}
