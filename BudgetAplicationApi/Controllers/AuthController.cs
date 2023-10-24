using BudgetAplicationApi.Api.Dto;
using BudgetAplicationApi.Api.Interfaces;
using BudgetAplicationApi.Api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAplicationApi.Controllers
{
    [ApiController]
    [Route("api/service/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUsuariosService userService;
        private readonly IAuthFacade authFacade;
        public AuthController(IUsuariosService _UsuariosService, IAuthFacade _authFacade)
        {
            authFacade = _authFacade;
            userService = _UsuariosService;
        }

/*        [HttpGet, Authorize(Roles = "SuperAdmin")]
        public async Task<ActionResult> GetAll()
        {
            List<Usuarios> UsuariosList = await userService.GetUsuariosListAsync();
            return Ok(mapper.Map<List<UsuariosDto>>(UsuariosList));
        }*/

/*        [HttpGet("find-by-id"), Authorize(Roles = "Admin")]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<ActionResult> GetById(long id)
        {
            Usuarios UsuariosList = await userService.FindUsuariosById(id);

            if (UsuariosList == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<UsuariosDto>(UsuariosList));
        }*/

/*        [HttpPost]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<ActionResult> Create(UsuariosCreationDto user)
        {
            //Encrypting Password
            user.Password = await authFacade.Hash(user.Password);

            if (await userService.IsUsuariosNameInUsed(user.Usuariosname))
            {
                return BadRequest("UsuariosName already in used.");
            }

            if (await userService.IsUsuariosIdentificationInUsed(user.ContactInformation?.IdentificationNumber))
            {
                return BadRequest("Identification number already in used.");
            }

            var result = await userService.CreateUsuariosAsync(mapper.Map<Usuarios>(user));
            return Ok(mapper.Map<UsuariosDto>(result));
        }*/


        [HttpPost("login")]
        public async Task<ActionResult> Login(UsuariosLoginDto user)
        {
            if (!await authFacade.VerifyLogin(user.Password, user.Username))
            {
                return BadRequest("Usuarios Not Found Or Incorrect Password");
            }
            //Generate Token
            String token = authFacade.CreateJwtToken(user.Username);
            UserJwtDto tokenResponse = new UserJwtDto();
            tokenResponse.Token = token;

            return Ok(tokenResponse);
        }

/*        [HttpPut]
        [Authorize(Roles = "SuperAdmin")]
        public async Task<ActionResult> Update(UsuariosDto userDto)
        {
            Usuarios user = await userService.FindUsuariosById(userDto.Id);
            if (user == null)
            {
                return NotFound();
            }
            String username = userDto.Usuariosname ?? user.Usuariosname;
            if (user.Usuariosname != username && await userService.IsUsuariosNameInUsed(username))
            {
                return BadRequest("UsuariosName already in used.");
            }

            String identification = userDto.ContactInformation?.IdentificationNumber ?? user.ContactInformation?.IdentificationNumber;
            if (identification != user.ContactInformation?.IdentificationNumber &&
                await userService.IsUsuariosIdentificationInUsed(identification))
            {
                return BadRequest("Identification number already in used.");
            }

            await userService.UpdateUsuariosAsync(mapper.Map<Usuarios>(userDto));
            return Ok();
        }*/
    }
}