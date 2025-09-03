using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IAuthservice
    {
        Task<UserResultDto>LoginAsync(LoginDto loginDto);
        Task<UserResultDto> RegisterAsync(RefisterDto refisterDto);

    }
}
