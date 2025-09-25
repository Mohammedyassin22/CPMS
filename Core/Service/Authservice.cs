using AutoMapper;
using Domain.Exceptions;
using Domain.Models;
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

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MimeKit;
using ServiceAbstraction;
using Shared;
using System.IdentityModel.Tokens.Jwt;

using System.Security.Claims;
using System.Text;

namespace Service
{

    public class Authservice(UserManager<AppUsers>userManager,IOptions<JWTOptions>options) : IAuthservice

    public class Authservice(UserManager<AppUsers>userManager,IOptions<JWTOptions>options,IMapper mapper, SignInManager<AppUsers> signInManager) : IAuthservice

    {
        public async Task<bool> CheckEmailExistAsync(string email)
        {
            var result= userManager.FindByEmailAsync(email);
            return result != null;
        }

        public async Task<AddressDto> GetCurrentUserAddress(string email)
        {
          var user=await userManager.Users.Include(x=>x.Address).FirstOrDefaultAsync(x=>x.Email==email);
            if(user is null)
            {
                throw new UserNotFoundException($"User with email {email} not found.");
            }
           var result=mapper.Map<AddressDto>(user.Address);
            return result;
        }

        public async Task<UserResultDto> GetCurrentUserAsync(string email)
        {
            var result = await userManager.FindByEmailAsync(email);
            if (result is null)
            {
                throw new UserNotFoundException($"User with email {email} not found");
            }
            return new UserResultDto()
            {
                DisplayName = result.DisplayName,
                Email = result.Email,
                Token = await GenerateToken(result)
            };
        }

        public async Task<List<InvoiceDto>> GetUserInvoicesAsync(string email)
        {
            var user = userManager.Users.Include(x => x.Invoices).FirstOrDefault(x => x.Email == email);
            if (user is null)
            {
                throw new UserNotFoundException($"User with email {email} not found.");
            }
            var result = mapper.Map<List<InvoiceDto>>(user.Invoices);
            return result;
        }

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

                Token = await GenerateTokenAsync(result)

                Token = await GenerateToken(result)
            };
        }

        public async Task<UserResultDto> LogoutAsync()
        {
            await signInManager.SignOutAsync();

            return new UserResultDto
            {
                DisplayName = null,  
                Email = null,
                Token = null

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

                Token=await GenerateTokenAsync(user)
            };
        }

        private async Task<string>GenerateTokenAsync(AppUsers user)
        {
            var JWTOptions=options.Value;
            var authclain=new List<Claim>()
            {
                new Claim(ClaimTypes.Email,user.Email),
                new Claim(ClaimTypes.Name,user.DisplayName)
            };
            var rolus= userManager.GetRolesAsync(user);
            foreach(var role in rolus.Result)
            {
                authclain.Add(new Claim(ClaimTypes.Role, role));
            }
            var secretekey=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JWTOptions.SecreteKey));
            var token =new JwtSecurityToken(
            issuer: JWTOptions.Issuer,
            audience: JWTOptions.Audience,
            claims: authclain,
            expires: DateTime.UtcNow.AddDays(JWTOptions.DurationInDays)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

                Token=await GenerateToken(user)
            };
        }

        public async Task<AddressDto> UpdateUserAddress(string email, AddressDto address)
        {
            var user = await userManager.Users.Include(x => x.Address).FirstOrDefaultAsync(x => x.Email == email);
            if (user is null)
            {
                throw new UserNotFoundException($"User with email {email} not found.");
            }
            if(user.Address is not null)
            {
                user.Address.FirstName = address.FirstName;
                user.Address.LastName = address.LastName;
            user.Address.PhoneNumber= address.PhoneNumber;
                user.Address.Street = address.Street;
                user.Address.city = address.city;
            }
            else
            {
                var addressRecord = mapper.Map<Address>(address);
                user.Address = addressRecord;
            }
            return address;
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

        public async Task<string> ResetePassword(ResetePasswordDto dto)
        {
            var user = await userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                throw new UserNotFoundException($"User with email {dto.Email} not found.");
            }
            if (string.IsNullOrEmpty(dto.Token))
            {
                throw new ArgumentException("Reset token is invalid.");
            }

            if (dto.Password != dto.ConfirmPassword)
            {
                return "Password and ConfirmPassword do not match.";
            }

            var result = await userManager.ResetPasswordAsync(user, dto.Token, dto.Password);

            if (!result.Succeeded)
            {
                var errors = string.Join(" | ", result.Errors.Select(e => e.Description));
                return $"Reset password failed: {errors}";
            }

            return "Password has been reset successfully.";
        }

    }
}
