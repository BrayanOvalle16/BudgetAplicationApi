﻿using AutoMapper;
using BudgetAplicationApi.Api.Dto;
using BudgetAplicationApi.Api.Exceptions;
using BudgetAplicationApi.Api.Interfaces;
using BudgetAplicationApi.Api.Models;
using BudgetAplicationApi.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAplicationApi.Controllers
{
    [Route("api/v1/usuarios")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosService _usuariosService;
        private readonly IMapper _mapper;
        private readonly IAuthFacade _authFacade;
        private readonly string regex = "^(?=.*[0-9])"
                       + "(?=.*[a-z])(?=.*[A-Z])"
                       + "(?=.*[@#$%^&+=])"
                       + "(?=\\S+$).{8,20}$";
        public UsuariosController(IUsuariosService usuariosService, IMapper mapper, IAuthFacade authFacade)
        {
            _mapper = mapper;
            _authFacade = authFacade;
            _usuariosService = usuariosService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            var usuarios = await _usuariosService.GetAllUsuariosAsync();
            var usuariosDto = _mapper.Map<IEnumerable<UsuariosDto>>(usuarios);
            return Ok(usuariosDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            var usuario = await _usuariosService.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            var usuariosDto = _mapper.Map<UsuariosDto>(usuario);
            return Ok(usuariosDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] UsuariosCreate usuarioDto)
        {
            var usuario = _mapper.Map<Usuarios>(usuarioDto);
            usuario.Contrasena = await _authFacade.Hash(usuario.Contrasena);
            await _usuariosService.CreateUsuarioAsync(usuario);
            var usuarioDtos = _mapper.Map<UsuariosDto>(usuario);
            return CreatedAtAction("GetUsuarioById", new { id = usuario.ID }, usuarioDtos);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario(int id, [FromBody] UsuariosUpdate usuarioDto)
        {
            try
            {
                var usuario = _mapper.Map<Usuarios>(usuarioDto);
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
