namespace BudgetAplicationApi.Api.Models
{
    public class Transaccion
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public ICollection<Movimiento> Movimientos { get; set; }
    }
}
