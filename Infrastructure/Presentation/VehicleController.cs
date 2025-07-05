using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [ApiController]
    [Route("api/[controller]")]
    public class VehicleController(IServiceManager serviceManager):ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllVehcile()
        {
            var result =await serviceManager.VehicleService.GetAllVehiclesAsync();
            if (result is null)
                return BadRequest();
            return Ok(result);  
        }

        [HttpGet("Type")]
        public async Task <ActionResult<VehicleTypeDto>> GetAllVehicleBType(string VehicleType)
        {
           var result = await serviceManager.VehicleService.GetAllVehicleBTypeAsync(VehicleType);
            if (result == null || !result.Any())
                return NotFound();
           return Ok(result);
        }
        [HttpGet("PlatNumber")]
        public async Task<ActionResult<VehicleDto>> GetAllByNumber(string PlatNumber)
        {
            var result = await serviceManager.VehicleService.GetVehicleByNumberAsync(PlatNumber);
            if (result == null)
                return NotFound();
            return Ok(result);
        }
        [HttpGet("Owner")]
        public async Task<ActionResult<VehicleTypeDto>> GetAllVehicleBOwner(string Owner)
        {
            var result = await serviceManager.VehicleService.GetVehicleOwnersAsync(Owner);
            if (result == null || !result.Any())
                return NotFound();
            return Ok(result);
        }
    }
}
