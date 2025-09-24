using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using Shared.ErrorDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ParkingRecordController(IServiceManager serviceManager):ControllerBase
    {
        [HttpGet("platnumber")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<ParkingRecordDto, RecordSpecifcationParameter>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<ParkingRecordDto?>> GetRecord(string platnumber)
        {
            var result= await serviceManager.ParkingRecordService.GetRecord(platnumber);
            return result;
        }

        [HttpGet("GetRecord")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<ParkingRecordDto, RecordSpecifcationParameter>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<ParkingRecordDto?>> GetEntryTime(string platnumber)
        {
            var result = await serviceManager.ParkingRecordService.GetRecord(platnumber);
            return result;
        }

        [HttpGet("GetExit")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<ParkingRecordDto, RecordSpecifcationParameter>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<ParkingRecordDto?>> GetExit(string platnumber)
        {
            var result = await serviceManager.ParkingRecordService.GetExit(platnumber);
            return result;
        }

        [HttpPost("EntryTime")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<ParkingRecordDto, RecordSpecifcationParameter>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<ParkingRecordDto>> RegisterEntry(string plateNumber, string zoneName)
        {
            var result = await serviceManager.ParkingRecordService.RegisterEntry(plateNumber, zoneName);
            return result;
        }
    }
}
