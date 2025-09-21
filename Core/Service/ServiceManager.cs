using AutoMapper;
using Domain.Contracts;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ServiceAbstraction;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager(IUnitOfWork unitOfWork,UserManager<AppUsers>userManagers ,IMapper mapper,ICacheRepository repository,IConfiguration configuration,IOptions<JWTOptions>options,SignInManager<AppUsers>signInManager) : IServiceManager
    {
        public IVehicleService<VehicleSpecificationParameter, VehicleDto> VehicleService { get; }= new VehicleService(unitOfWork, mapper);
        public ICacheService CacheService { get; } = new CacheServices(repository);
        public IAuthservice AuthService { get; }=new Authservice(userManagers,options,mapper,signInManager);

        public IZoneServices ZoneService { get; } =new ZoneServices(unitOfWork,mapper);

        public IParkingRecordServices ParkingRecordService { get; }=new ParkingRecordServices(unitOfWork,mapper);

        public IInvoiceServices invoiceServices { get; } = new InvoiceServices(unitOfWork, mapper);

        public IPamentServices PaymentService { get; } = new PaymentServices(unitOfWork, mapper,configuration);
    }
}
