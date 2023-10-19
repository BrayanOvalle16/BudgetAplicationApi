namespace BudgetAplicationApi.Api.Models
{
    public class Movimiento
    {
        public int ID { get; set; }
        public int Monto { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }

        // Propiedades de navegación para las relaciones Usuario, Compañia, Contabilidad y Transacción
        public Usuarios Usuario { get; set; }
        public Compania Compañia { get; set; }
        public Contabilidad Contabilidad { get; set; }
        public Transaccion Transaccion { get; set; }
    }
}
