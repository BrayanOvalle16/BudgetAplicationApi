namespace BudgetAplicationApi.Api.Models
{
    public class Compania
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public int IngresoTotal { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }
        public ICollection<Movimiento> Movimientos { get; set; }
    }
}
