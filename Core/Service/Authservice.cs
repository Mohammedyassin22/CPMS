using Domain.Exceptions;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceAbstraction;
using Shared;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Authservice(UserManager<AppUsers>userManager,IOptions<JWTOptions>options) : IAuthservice
    {
        public async Task<UserResultDto> LoginAsync(LoginDto loginDto)
        {
            var result=await userManager.FindByEmailAsync(loginDto.Email);
            if(result is null)
            {
                throw new UnAuthorizedException();
            }
            var isValid=await userManager.CheckPasswordAsync(result,loginDto.Password);
            if (!isValid)
            {
                throw new UnAuthorizedException();
            }
            return new UserResultDto()
            {
                DisplayName = result.DisplayName,
                Email = result.Email,
                Token = await GenerateToken(result)
            };
        }

        public async Task<UserResultDto> RegisterAsync(RefisterDto refisterDto)
        {
            var user=new AppUsers()
            {
                DisplayName = refisterDto.DisplayName,
                Email = refisterDto.Email,
                UserName = refisterDto.Email
            };
            var result = await userManager.CreateAsync(user, refisterDto.Password);
            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e => e.Description).ToList();
                throw new ValidationException(errors);
            }
            return new UserResultDto()
            {
                DisplayName = user.DisplayName,
                Email = user.Email,
                Token=await GenerateToken(user)
            };
        }

        private async Task<string> GenerateToken(AppUsers user)
        {
            var jwtoptions=options.Value;
           var authclaims = new List<Claim>
           {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email,user.Email)
            };
            var roles = await userManager.GetRolesAsync(user);
            foreach (var role in roles)
            {
                authclaims.Add(new Claim(ClaimTypes.Role, role));
            }

           var secretkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtoptions.SecretKey));
            var token = new JwtSecurityToken(
                issuer: jwtoptions.Issuer ,
                audience: jwtoptions.Audience,
                claims: authclaims,
                expires: DateTime.UtcNow.AddDays((jwtoptions.DurationInDays)),
                signingCredentials: new SigningCredentials(secretkey, SecurityAlgorithms.HmacSha256Signature)
             );                
            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}
