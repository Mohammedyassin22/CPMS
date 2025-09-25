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
    public class ParkingRecordServices(IUnitOfWork unitOfWork, IMapper mapper) : IParkingRecordServices
    {

        public async Task<ParkingRecordDto> RegisterEntry(string plateNumber, string zoneName)
        {
            var record = new ParkingRecordDto
            {
                PlateNumber = plateNumber,
                ZoneName = zoneName,
                EntryTime = DateTime.Now,
                invoiceId = new Random().Next(1000, 9999)
            };

            var entity = mapper.Map<ParkingRecord>(record);

            await unitOfWork.GetRebository<ParkingRecord,int>().AddAsync(entity);
            await unitOfWork.SaveChangeAsync();

            return mapper.Map<ParkingRecordDto>(entity);
        }
        public async Task<ParkingRecordDto?> GetRecord(string plateNumber)
        {
            var entity = await unitOfWork
                .GetRebository<ParkingRecord, int>()
                .FindAsync(new RecordFindSpecfication(plateNumber));

            if (entity == null) return null;

            return mapper.Map<ParkingRecordDto>(entity);
        }

        public async Task<ParkingRecordDto?> GetExit(string plateNumber)
        {
            var entity = await unitOfWork.GetRebository<ParkingRecord, int>()
            .FindAsync(new RecordFindSpecfication(plateNumber));
            if (entity == null) return null;

            entity.ExitTime = DateTime.Now;

            unitOfWork.GetRebository<ParkingRecord,int>().Update(entity);
            await unitOfWork.SaveChangeAsync();

            return mapper.Map<ParkingRecordDto>(entity);
        }
    }
}
