using Domain.Models;
using Domain.Models.Identity;
using Domain.SecurityModules;
using Microsoft.AspNetCore.Identity;
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
    public class AuthController(IServiceManager serviceManager,UserManager<IdentityUser>userManager): ControllerBase
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

        [HttpPost("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await serviceManager.AuthService.LogoutAsync();
            return Ok();
        }

        [HttpPost("ForgetPassword")]
        public async Task<IActionResult> ForgetPasswordAsync(string email)
        {
            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
                return BadRequest("User not found");

            var token = await userManager.GeneratePasswordResetTokenAsync(user);

            var url = Url.Action("ResetPassword", "Auth", new { email = email, token = token }, Request.Scheme);

            var emailRequest = new Email
            {
                To = email,
                Subject = "Reset Password",
                Body = $"Click the link to reset your password: {url}"
            };

           serviceManager.AuthService.SendEmailAsync(emailRequest);

            return Ok("Reset link has been sent to your email");
        }

        [HttpPost("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetePasswordDto Dto)
        {
            var result = await serviceManager.AuthService.ResetePassword(Dto);
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

        [HttpGet("currentaddress")]
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
        
        [HttpGet("EmailExist")]
        public async Task<IActionResult> CheckEmailExistAsync( string email)
        {
            var result = await serviceManager.AuthService.CheckEmailExistAsync(email);
            return Ok(result);
        }
    }
}
