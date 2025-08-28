using Domain.Exceptions;
using Domain.Models;
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
    public class ZoneController(IServiceManager serviceManager):ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<ParkingZoneDto, ZoneSpecificationParameter>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<PaginationResponse<ParkingZoneDto, ZoneSpecificationParameter>>> GetAllZone(ZoneSpecificationParameter parameter)
        {
            var result=await serviceManager.ZoneService.GetAllZone(parameter);
            return result;
        }
        [HttpGet("zone")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<ParkingZoneDto, ZoneSpecificationParameter>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<ParkingZoneDto?>> GetZoneByZone(string Zone)
        {
           var result=await serviceManager.ZoneService.GetZoneByZone(Zone);
            return result;
        }
    }
}
