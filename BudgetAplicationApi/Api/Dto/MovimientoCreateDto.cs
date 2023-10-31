using BudgetAplicationApi.Api.Models;

namespace BudgetAplicationApi.Api.Dto
{
    public class MovimientoCreateDto
    {
        public int Monto { get; set; }
        public string Descripcion { get; set; }
        public int ContabilidadId { get; set; }
    }
}
