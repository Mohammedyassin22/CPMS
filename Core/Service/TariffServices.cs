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
    public class TariffServices(IMapper mapper, IUnitOfWork unitOfWork) : ITariffServices
    {
        public async Task<bool> SetTariffAsync(TariffsDto dto)
        {
            var tariff = mapper.Map<Tariff>(dto);
            var repo = unitOfWork.GetRebository<Tariff, int>();
            repo.Update(tariff);
            return await unitOfWork.SaveChangeAsync() > 0;
        }

        public async Task<TariffsDto> GetTariffAsync(string vehicleType)
        {
            var repo = unitOfWork.GetRebository<Tariff, int>();

            var tariff = (await repo.GetAllAsync()).FirstOrDefault(t => t.VehicleType.ToString() == vehicleType);

            return mapper.Map<TariffsDto>(tariff);
        }
    }

}
