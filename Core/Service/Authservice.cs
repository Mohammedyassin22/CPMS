using Domain.Exceptions;
using Domain.Models.Identity;
using Microsoft.AspNetCore.Identity;
using ServiceAbstraction;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class Authservice(UserManager<AppUsers>userManager) : IAuthservice
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
                Token = "Token"
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
                Token="Token"
            };
        }
    }
}
