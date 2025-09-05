using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceAbstraction;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAsync(RefisterDto refisterDto)
        {
            var user = await serviceManager.AuthService.RegisterAsync(refisterDto);
            return Ok(user);
        }

        [HttpGet("EmailExist")]
        public async Task<IActionResult> CheckEmailExistAsync( string email)
        {
            var result = await serviceManager.AuthService.CheckEmailExistAsync(email);
            return Ok(result);
        }

        [HttpGet("currentUser")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUserAsync(string email)
        {
            var address = User.FindFirstValue(ClaimTypes.Email);
            var user = await serviceManager.AuthService.GetCurrentUserAsync(email);
            return Ok(user);
        }

        [HttpGet("address")]
        [Authorize]
        public async Task<IActionResult> GetCurrentUserAddress(string email)
        {
            var address = User.FindFirstValue(ClaimTypes.Email);
            var result = await serviceManager.AuthService.GetCurrentUserAddress(email);
            return Ok(result);
        }

        [HttpPut("address")]
        [Authorize]
        public async Task<IActionResult> UpdateUserAddress(string email, AddressDto addressDto)
        {
            var address = User.FindFirstValue(ClaimTypes.Email);
            var result = await serviceManager.AuthService.UpdateUserAddress(email, addressDto);
            return Ok(result);
        }

        [HttpGet("invoices")]
        [Authorize]
        public async Task<IActionResult> GetUserInvoicesAsync(string email)
        {
            var address = User.FindFirstValue(ClaimTypes.Email);
            var result = await serviceManager.AuthService.GetUserInvoicesAsync(email);
            return Ok(result);
        }
    }
}
