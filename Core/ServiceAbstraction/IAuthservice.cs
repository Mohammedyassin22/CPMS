using Domain.Models;
using Domain.Models.Identity;
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
        Task<bool>CheckEmailExistAsync(string email);
        Task<UserResultDto>GetCurrentUserAsync(string email);
        Task<AddressDto> GetCurrentUserAddress(string email);
        Task<AddressDto> UpdateUserAddress(string email,AddressDto address);
        Task<List<InvoiceDto>> GetUserInvoicesAsync(string email);
        Task<UserResultDto>LogoutAsync();
        Task<string> ResetePassword(ResetePasswordDto Dto);
        Task SendEmailAsync(Email email);
    }

}
