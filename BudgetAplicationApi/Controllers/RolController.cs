using BudgetAplicationApi.Api.Exceptions;
using BudgetAplicationApi.Api.Models;
using BudgetAplicationApi.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAplicationApi.Controllers
{
    [Route("api/v1/roles")]
    [ApiController]
    public class RolController : ControllerBase
    {
        private readonly RolService _rolService;

        public RolController(RolService rolService)
        {
            _rolService = rolService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles()
        {
            var roles = await _rolService.GetAllRolesAsync();
            return Ok(roles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var rol = await _rolService.GetRoleByIdAsync(id);
            if (rol == null)
            {
                return NotFound();
            }

            return Ok(rol);
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole([FromBody] Rol rol)
        {
            await _rolService.CreateRoleAsync(rol);
            return CreatedAtAction("GetRoleById", new { id = rol.ID }, rol);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] Rol rol)
        {
            try
            {
                await _rolService.UpdateRoleAsync(id, rol);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            await _rolService.DeleteRoleAsync(id);
            return NoContent();
        }
    }
}
