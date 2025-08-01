using AutoMapper;
using Domain.Contracts;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager(IUnitOfWork unitOfWork, IMapper mapper,ICacheRepository repository,UserManager<AppUsers> userManager) : IServiceManager
    {
        public IVehicleService VehicleService { get; }= new VehicleService(unitOfWork, mapper);
        public ICacheService CacheService { get; } = new CacheServices(repository);
        public IAuthservice AuthService { get; }=new Authservice(userManager);
    }
}
