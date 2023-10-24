using BudgetAplicationApi.Api.Models;

namespace BudgetAplicationApi.Api.Dto
{
    public class UsuariosDto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumeroIdentificacion { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;
        public bool Estado { get; set; } = true;

        public ICollection<Rol> Roles { get; set; }

        // Propiedad de navegación para la relación Movimiento
        public ICollection<Movimiento> Movimientos { get; set; }
    }
}
