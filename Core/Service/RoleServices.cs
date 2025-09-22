using AutoMapper;
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
    public class RoleServices(RoleManager<IdentityRole>roleManager,IMapper mapper): IRoleServices
    {
        public async Task<IEnumerable<AddOrRemoveUser>> GetAllRolesAsync()
        {
            var roles = roleManager.Roles.ToList();
            return mapper.Map<IEnumerable<AddOrRemoveUser>>(roles);
        }

        public async Task<AddOrRemoveUser> GetRoleByIdAsync(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            return mapper.Map<AddOrRemoveUser>(role);
        }

        public async Task<bool> CreateRoleAsync(AddOrRemoveUser roleDto)
        {
            var role = new IdentityRole { Name = roleDto.UserName };
            var result = await roleManager.CreateAsync(role);
            return result.Succeeded;
        }

        public async Task<bool> UpdateRoleAsync(AddOrRemoveUser roleDto)
        {
            var role = await roleManager.FindByIdAsync(roleDto.UserId);
            if (role == null) return false;

            role.Name = roleDto.UserName;
            var result = await roleManager.UpdateAsync(role);
            return result.Succeeded;
        }

        public async Task<bool> DeleteRoleAsync(string id)
        {
            var role = await roleManager.FindByIdAsync(id);
            if (role == null) return false;

            var result = await roleManager.DeleteAsync(role);
            return result.Succeeded;
        }
    }
}
