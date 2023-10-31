using BudgetAplicationApi.Api.Models;

namespace BudgetAplicationApi.Api.Dto
{
    public class CompaniaDto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int IngresoTotal { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public bool Estado { get; set; } = true;
        public ICollection<Movimiento> Movimientos { get; set; }
    }
}
