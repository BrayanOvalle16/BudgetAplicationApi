using BudgetAplicationApi.Api.Models;

namespace BudgetAplicationApi.Api.Dto
{
    public class ContabilidadDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Naturaleza { get; set; }
        public bool Estado { get; set; } = true;
        public DateTime Fecha { get; set; } = DateTime.Now;
    }
}
