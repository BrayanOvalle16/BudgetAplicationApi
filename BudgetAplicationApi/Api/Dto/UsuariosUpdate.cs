using BudgetAplicationApi.Api.Models;

namespace BudgetAplicationApi.Api.Dto
{
    public class UsuariosUpdate
    {
        public string Nombre { get; set; }
        public string CorreoElectronico { get; set; }
        public string NumeroIdentificacion { get; set; }
    }
}
