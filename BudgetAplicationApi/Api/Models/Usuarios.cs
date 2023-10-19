namespace BudgetAplicationApi.Api.Models
{
    public class Usuarios
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contraseña { get; set; }
        public string NumeroIdentificacion { get; set; }
        public DateTime Fecha { get; set; }
        public bool Estado { get; set; }

        public ICollection<Rol> Roles { get; set; }

        // Propiedad de navegación para la relación Movimiento
        public ICollection<Movimiento> Movimientos { get; set; }
    }
}
