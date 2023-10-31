using BudgetAplicationApi.Api.Models;

namespace BudgetAplicationApi.Api.Dto
{
    public class MovimientoUpdateDto
    {
        public int ID { get; set; }
        public int Monto { get; set; }
        public string Descripcion { get; set; }
        public int ContabilidadId { get; set; }
    }
}
