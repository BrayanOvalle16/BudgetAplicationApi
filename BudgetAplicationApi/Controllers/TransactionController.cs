using AutoMapper;
using BudgetAplicationApi.Api.Dto;
using BudgetAplicationApi.Api.Interfaces;
using BudgetAplicationApi.Api.Models;
using BudgetAplicationApi.Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAplicationApi.Controllers
{
    [ApiController]
    [Route("api/v1/transaccion")]
    [Authorize(Roles = "Admin, Contador")]
    public class TransaccionController : ControllerBase
    {
        private readonly ITransaccionService _companiaService;
        private readonly IMapper _mapper;

        public TransaccionController(ITransaccionService companiaService, IMapper mapper)
        {
            _companiaService = companiaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetTransaccions()
        {
            var companias = _companiaService.GetAllTransaccions();
            return Ok(_mapper.Map<IEnumerable<TransaccionDto>>(companias));
        }

        [HttpGet("{id}")]
        public IActionResult GetTransaccion(int id)
        {
            var compania = _companiaService.GetTransaccion(id);
            if (compania == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TransaccionDto>(compania));
        }

        [HttpPost]
        public IActionResult CreateTransaccion(TransaccionCreateDto compania)
        {
            var newTransaccion = _companiaService.CreateTransaccion(_mapper.Map<Transaccion>(compania));
            return CreatedAtAction(nameof(GetTransaccion), new { id = newTransaccion.ID }, newTransaccion);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateTransaccion(int id, TransaccionUpdateDto compania)
        {
            var updatedTransaccion = _companiaService.UpdateTransaccion(_mapper.Map<Transaccion>(compania));
            return Ok(updatedTransaccion);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteTransaccion(int id)
        {
            _companiaService.DeleteTransaccion(id);
            return NoContent();
        }
    }
}
