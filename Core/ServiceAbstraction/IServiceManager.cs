using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IServiceManager
    {
        IVehicleService<VehicleSpecificationParameter, VehicleDto> VehicleService { get; }
        ICacheService CacheService { get; }
        IAuthservice AuthService { get; }
        IZoneServices ZoneService { get; }
        IParkingRecordServices ParkingRecordService { get; }
        IInvoiceServices invoiceServices { get; }
        IPamentServices PaymentService { get; }
        IRoleServices RoleService { get; }
        ITariffServices TariffService { get; }
    }
}
