using AutoMapper;
using BudgetAplicationApi.Api.Dto;
using BudgetAplicationApi.Api.Interfaces;
using BudgetAplicationApi.Api.Models;
using BudgetAplicationApi.Business.Services;
using Microsoft.AspNetCore.Mvc;

namespace BudgetAplicationApi.Controllers
{
    [ApiController]
    [Route("api/v1/companias")]
    public class CompaniaController : ControllerBase
    {
        private readonly ICompaniaService _companiaService;
        private readonly IMapper _mapper;

        public CompaniaController(ICompaniaService companiaService, IMapper mapper)
        {
            _companiaService = companiaService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetCompanias()
        {
            var companias = _companiaService.GetAllCompanias();
            return Ok(_mapper.Map<IEnumerable<CompaniaDto>>(companias));
        }

        [HttpGet("{id}")]
        public IActionResult GetCompania(int id)
        {
            var compania = _companiaService.GetCompania(id);
            if (compania == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CompaniaDto>(compania));
        }

        [HttpPost]
        public IActionResult CreateCompania(CompaniaCreate compania)
        {
            var newCompania = _companiaService.CreateCompania(_mapper.Map<Compania>(compania));
            return CreatedAtAction(nameof(GetCompania), new { id = newCompania.ID }, newCompania);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCompania(int id, CompaniaUpdate compania)
        {
            var updatedCompania = _companiaService.UpdateCompania(_mapper.Map<Compania>(compania));
            return Ok(updatedCompania);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCompania(int id)
        {
            _companiaService.DeleteCompania(id);
            return NoContent();
        }
    }
}
