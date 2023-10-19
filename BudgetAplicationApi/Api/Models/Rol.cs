namespace BudgetAplicationApi.Api.Models
{
    public class Rol
    {
        public int ID { get; set; }
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime Fecha { get; set; }

        // Propiedad de navegación para la relación UsuarioRol
        public ICollection<Usuarios> UsuariosRoles { get; set; }
    }
}
