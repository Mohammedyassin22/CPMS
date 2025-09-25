using AutoMapper;
using Domain.Contracts;
using Domain.Models;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;

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
    public class ServiceManager(IUnitOfWork unitOfWork, IMapper mapper,ICacheRepository repository,UserManager<AppUsers> userManager, IOptions<JWTOptions> option) : IServiceManager

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using ServiceAbstraction;
using Shared;

namespace Service
{
    public class ServiceManager(IUnitOfWork unitOfWork,UserManager<AppUsers>userManagers ,IMapper mapper,ICacheRepository repository,IConfiguration configuration,IOptions<JWTOptions>options,SignInManager<AppUsers>signInManager,RoleManager<IdentityRole>roleManager,IOptions<MailSetting>options1) : IServiceManager

    {
        public IVehicleService<VehicleSpecificationParameter, VehicleDto> VehicleService { get; }= new VehicleService(unitOfWork, mapper);
        public ICacheService CacheService { get; } = new CacheServices(repository);

        public IAuthservice AuthService { get; }=new Authservice(userManager,option);

        public IAuthservice AuthService { get; }=new Authservice(userManagers,options,mapper,signInManager);

        public IZoneServices ZoneService { get; } =new ZoneServices(unitOfWork,mapper);

        public IParkingRecordServices ParkingRecordService { get; }=new ParkingRecordServices(unitOfWork,mapper);

        public IInvoiceServices invoiceServices { get; } = new InvoiceServices(unitOfWork, mapper);

        public IPamentServices PaymentService { get; } = new PaymentServices(unitOfWork, mapper,configuration);

        public IRoleServices RoleService { get; }=new RoleServices(roleManager,mapper);

        public ITariffServices TariffService => throw new NotImplementedException();

        public IMailServices MailServices { get; } =new MailServices(options1);

    }
}
