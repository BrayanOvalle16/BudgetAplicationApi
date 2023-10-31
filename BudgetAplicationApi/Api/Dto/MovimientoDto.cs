using BudgetAplicationApi.Api.Models;

namespace BudgetAplicationApi.Api.Dto
{
    public class MovimientoDto
    {
        public int ID { get; set; }
        public int Monto { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }
        public bool Estado { get; set; } = true;
        public ContabilidadDto Contabilidad { get; set; }
        public TransaccionDto Transaccion { get; set; }
    }
}
