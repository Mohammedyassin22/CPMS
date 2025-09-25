using Microsoft.AspNetCore.Authorization;
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
    [Authorize(Roles = "Admin")]
    public class RoleController(IServiceManager serviceManager) : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var roles = await serviceManager.RoleService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var role = await serviceManager.RoleService.GetRoleByIdAsync(id);
            if (role == null) return NotFound();
            return Ok(role);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddOrRemoveUser roleDto)
        {
            var result = await serviceManager.RoleService.CreateRoleAsync(roleDto);
            if (!result) return BadRequest("Failed to create role");
            return Ok("Role created successfully");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, AddOrRemoveUser roleDto)
        {
            roleDto.UserId = id;
            var result = await serviceManager.RoleService.UpdateRoleAsync(roleDto);
            if (!result) return BadRequest("Failed to update role");
            return Ok("Role updated successfully");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var result = await serviceManager.RoleService.DeleteRoleAsync(id);
            if (!result) return BadRequest("Failed to delete role");
            return Ok("Role deleted successfully");
        }
    }

}
