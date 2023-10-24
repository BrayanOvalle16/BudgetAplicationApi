namespace BudgetAplicationApi.Api.Models
{
    public class Contabilidad
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public bool Naturaleza { get; set; }
        public bool Estado { get; set; } = true;
        public DateTime Fecha { get; set; } = DateTime.Now;

        // Propiedad de navegación para la relación Movimiento
        public ICollection<Movimiento> Movimientos { get; set; }
    }
}
