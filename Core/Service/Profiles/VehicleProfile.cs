using AutoMapper;
using Domain.Models;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Profiles
{
    public class VehicleProfile:Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleDto>().ForMember(x => x.VehicleType, z => z.MapFrom(x => x.VehicleType.TypeName))
                                            .ForMember(x => x.OwnerNAme, z => z.MapFrom(x => x.Owner.FullName));
        }
    }
}
