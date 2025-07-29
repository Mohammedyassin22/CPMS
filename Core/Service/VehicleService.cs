using AutoMapper;
using Domain.Contracts;
using Domain.Exceptions;
using Domain.Models;
using Service.Specification;
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
            var spec = new VehicleSpecification(VehicleType);   
            var type = await unitOfWork.GetRebository<Vehicle, int>().FindAsync(spec);
            var result = mapper.Map<IEnumerable<VehicleDto>>(type);
            if (result is null)
            {
                throw  new VehicleNotFoundException(VehicleType);
            }
            return result;
        }

        public async Task<PaginationResponse<VehicleDto>> GetAllVehiclesAsync(VehicleSpecificationParameter specvehicle)
        {
            var spec= new VehicleSpecification(specvehicle);
            var speccount = new VehicleCountSpecification(specvehicle);
            var count = await unitOfWork.GetRebository<Vehicle, int>().CountAsync(spec);
            var vehicles = await unitOfWork.GetRebository<Vehicle, int>().GetAllAsync(spec);
            var result=mapper.Map<IEnumerable<VehicleDto>>(vehicles);
            return new PaginationResponse<VehicleDto>(specvehicle, specvehicle.IndexPage, specvehicle.PageSize, count,result);
        }

        public async Task<VehicleDto?> GetVehicleByNumberAsync(string plateNumber)
        {
            var spec = new VehicleSpecification(plateNumber);
            var vehicle = await unitOfWork.GetRebository<Vehicle, int>().FindAsync(spec);
            if(vehicle is null)
            {
                   return null;
            }
            var result = mapper.Map<VehicleDto>(vehicle);
            return result;
        }

        public async Task<IEnumerable<VehicleDto?>> GetVehicleOwnersAsync(string OwnerName)
        {
            var spec = new VehicleSpecification(OwnerName);
           var owner = await unitOfWork.GetRebository<Vehicle,int>().FindAsync(spec);
            var result = mapper.Map<IEnumerable<VehicleDto>>(owner);
            return result;
        }

       
    }
}
