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
    public class AuthController(IServiceManager serviceManager): ControllerBase
    {
        [HttpPost("login")] 
        public async Task<IActionResult> LoginAsync(LoginDto loginDto)
        {
            var user = await serviceManager.AuthService.LoginAsync(loginDto);
            return Ok(user);
        }
        public async Task<IActionResult> RegisterAsync(RefisterDto refisterDto)
        {
            var user = await serviceManager.AuthService.RegisterAsync(refisterDto);
            return Ok(user);
        }
    }
}
