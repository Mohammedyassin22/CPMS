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
    public class VehicleController(IServiceManager serviceManager):ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK,Type=typeof(PaginationResponse<VehicleDto, VehicleSpecificationParameter>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError,Type =typeof(ErrorDetails))]
        public async Task<IActionResult> GetAllVehcile([FromQuery]VehicleSpecificationParameter specvehicle)
        {
            var result =await serviceManager.VehicleService.GetAllVehiclesAsync(specvehicle);
           
            return Ok(result);  
        }

        [HttpGet("Type")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<VehicleTypeDto, VehicleSpecificationParameter>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        public async Task <ActionResult<VehicleTypeDto>> GetAllVehicleBType(string VehicleType)
        {
           var result = await serviceManager.VehicleService.GetAllVehicleBTypeAsync(VehicleType);
             return Ok(result);
        }

        [HttpGet("PlatNumber")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<VehicleDto, VehicleSpecificationParameter>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<VehicleDto>> GetAllByNumber(string PlatNumber)
        {
            var result = await serviceManager.VehicleService.GetVehicleByNumberAsync(PlatNumber);
             return Ok(result);
        }

        [HttpGet("Owner")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponse<VehicleTypeDto, VehicleSpecificationParameter>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(ErrorDetails))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ErrorDetails))]
        public async Task<ActionResult<VehicleTypeDto>> GetAllVehicleBOwner(string Owner)
        {
            var result = await serviceManager.VehicleService.GetVehicleOwnersAsync(Owner);
            return Ok(result);
        }
    }
}
