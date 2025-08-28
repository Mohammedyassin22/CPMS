using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IParkingRecordServices
    {
        Task<ParkingRecordDto?> GetRecord(string platnumber);
        Task<ParkingRecordDto> RegisterEntry(string plateNumber, string zoneName);
        Task<ParkingRecordDto?> GetExit(string plateNumber);
    }
}
