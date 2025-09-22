using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceAbstraction
{
    public interface IRoleServices
    {
        Task<IEnumerable<AddOrRemoveUser>> GetAllRolesAsync();
        Task<AddOrRemoveUser> GetRoleByIdAsync(string id);
        Task<bool> CreateRoleAsync(AddOrRemoveUser roleDto);
        Task<bool> UpdateRoleAsync(AddOrRemoveUser roleDto);
        Task<bool> DeleteRoleAsync(string id);
    }
}
