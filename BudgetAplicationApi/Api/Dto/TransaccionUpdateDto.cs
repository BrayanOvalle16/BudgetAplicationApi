using BudgetAplicationApi.Api.Models;

namespace BudgetAplicationApi.Api.Dto
{
    public class TransaccionUpdateDto
    {
        public string Nombre { get; set; }
        public ICollection<MovimientoUpdateDto> Movimientos { get; set; }
        public int UsuarioId { get; set; }
        public int CompaniaId { get; set; }
    }
}
