using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface ITariffServices
    {
        Task<bool> SetTariffAsync(TariffsDto dto);
        Task<TariffsDto> GetTariffAsync(string vehicleType);
    }
}
