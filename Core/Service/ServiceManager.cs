using AutoMapper;
using Domain.Contracts;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager(IUnitOfWork unitOfWork, IMapper mapper,ICacheRepository repository) : IServiceManager
    {
        public IVehicleService VehicleService { get; }= new VehicleService(unitOfWork, mapper);
        public ICacheService CacheService { get; } = new CacheServices(repository);
    }
}
