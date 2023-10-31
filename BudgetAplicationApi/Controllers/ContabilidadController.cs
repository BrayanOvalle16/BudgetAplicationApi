using AutoMapper;
using BudgetAplicationApi.Api.Dto;
using BudgetAplicationApi.Api.Interfaces;
using BudgetAplicationApi.Api.Models;
using BudgetAplicationApi.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAplicationApi.Controllers
{
    [ApiController]
    [Route("api/v1/contabilidad")]
    public class ContabilidadController : ControllerBase
    {
        private readonly IContabilidadService _companiaService;
        private readonly IMapper _mapper;

        public ContabilidadController(IContabilidadService companiaService, IMapper mapper)
        {
            _companiaService = companiaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetContabilidads()
        {
            var companias = _companiaService.GetAllContabilidads();
            return Ok(_mapper.Map<IEnumerable<ContabilidadDto>>(companias));
        }

        [HttpGet("{id}")]
        public IActionResult GetContabilidad(int id)
        {
            var compania = _companiaService.GetContabilidad(id);
            if (compania == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<ContabilidadDto>(compania));
        }

        [HttpPost]
        public IActionResult CreateContabilidad(ContabilidadCreateDto compania)
        {
            var newContabilidad = _companiaService.CreateContabilidad(_mapper.Map<Contabilidad>(compania));
            return CreatedAtAction(nameof(GetContabilidad), new { id = newContabilidad.Id }, newContabilidad);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContabilidad(int id, ContabilidadUpdateDto compania)
        {
            var updatedContabilidad = _companiaService.UpdateContabilidad(_mapper.Map<Contabilidad>(compania));
            return Ok(updatedContabilidad);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteContabilidad(int id)
        {
            _companiaService.DeleteContabilidad(id);
            return NoContent();
        }
    }
}
