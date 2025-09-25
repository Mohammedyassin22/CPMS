using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class TariffsController(IServiceManager serviceManager) : ControllerBase
    {

        [HttpPost("SetPrices")]
        public async Task<IActionResult> SetPrices([FromBody] TariffsDto dto)
        {
            var result = await serviceManager.TariffService.SetTariffAsync(dto);
            if (!result)
                return BadRequest("Failed to set tariff.");
            return Ok("Tariff updated successfully");
        }
    }
}
