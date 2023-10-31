namespace BudgetAplicationApi.Api.Models
{
    public class Movimiento
    {
        public int ID { get; set; }
        public int Monto { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public string Descripcion { get; set; }
        public bool Estado { get; set; } = true;
        public int ContabilidadId { get; set; }
        public Contabilidad Contabilidad { get; set; }
        public int TransaccionId { get; set; }
//        public Transaccion Transaccion { get; set; }
    }
}
