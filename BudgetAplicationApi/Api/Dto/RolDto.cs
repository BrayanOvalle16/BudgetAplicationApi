using BudgetAplicationApi.Api.Models;

namespace BudgetAplicationApi.Api.Dto
{
    public class RolDto
    {
        public int ID { get; set; }
        public RolesEnum Descripcion { get; set; }
        public bool Estado { get; set; }
        public DateTime Fecha { get; set; } = DateTime.Now;

    }
}
