using BudgetAplicationApi.Api.Models;

namespace BudgetAplicationApi.Api.Dto
{
    public class TransaccionCreateDto
    {
        public string Nombre { get; set; }
        public ICollection<MovimientoCreateDto> Movimientos { get; set; }
        public int UsuarioId { get; set; }
        public int CompaniaId { get; set; }
    }
}
