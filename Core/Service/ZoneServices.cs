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
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ZoneServices(IUnitOfWork unitOfWork, IMapper mapper) : IZoneServices
    {
        public async Task<PaginationResponse<ParkingZoneDto, ZoneSpecificationParameter>> GetAllZone(ZoneSpecificationParameter parameter)
        {
            var spec = new ZoneSpecification(parameter);
            var count = await unitOfWork.GetRebository<ParkingZone, int>().CountAsync(spec);
            var zone = await unitOfWork.GetRebository<ParkingZone, int>().GetAllAsync();
            var result = mapper.Map<IEnumerable<ParkingZoneDto>>(zone);
            return new PaginationResponse<ParkingZoneDto, ZoneSpecificationParameter>(parameter, parameter.IndexPage, parameter.PageSize, count, result);

        }

        public async Task<ParkingZoneDto?> GetZoneByZone(string Zone)
        {
            var type = await unitOfWork.GetRebository<ParkingZone, int>()
                                      .FindAllAsync(x => x.ZomeNAme == Zone);
            if (type is null)
                throw new ZoneNotFoundException(Zone);

            var result = mapper.Map<ParkingZoneDto>(type);
            return result;
        }

       
    }
}
