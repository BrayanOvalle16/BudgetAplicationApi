using BudgetAplicationApi.Api.Models;

namespace BudgetAplicationApi.Api.Dto
{
    public class UsuariosCreate
    {
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string Contrasena { get; set; }
        public string NumeroIdentificacion { get; set; }
        public bool Estado { get; set; }
    }
}
