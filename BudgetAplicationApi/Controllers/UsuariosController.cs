using BudgetAplicationApi.Api.Exceptions;
using BudgetAplicationApi.Api.Models;
using BudgetAplicationApi.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAplicationApi.Controllers
{
    [Route("api/v1/usuarios")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuariosService _usuariosService;

        public UsuariosController(UsuariosService usuariosService)
        {
            _usuariosService = usuariosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            var usuarios = await _usuariosService.GetAllUsuariosAsync();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            var usuario = await _usuariosService.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] Usuarios usuario)
        {
            await _usuariosService.CreateUsuarioAsync(usuario);
            return CreatedAtAction("GetUsuarioById", new { id = usuario.ID }, usuario);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] Usuarios usuario)
        {
            try
            {
                await _usuariosService.UpdateUsuarioAsync(id, usuario);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            await _usuariosService.DeleteUsuarioAsync(id);
            return NoContent();
        }
    }
}
