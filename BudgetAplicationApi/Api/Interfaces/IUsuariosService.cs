using BudgetAplicationApi.Api.Models;

namespace BudgetAplicationApi.Api.Interfaces
{
    public interface IUsuariosService
    {
        Task<IEnumerable<Usuarios>> GetAllUsuariosAsync();
        Task<Usuarios> GetUsuarioByIdAsync(int usuarioId);
        Task CreateUsuarioAsync(Usuarios usuario);
        Task UpdateUsuarioAsync(int usuarioId, Usuarios updatedUsuario);
        Task DeleteUsuarioAsync(int usuarioId);
        Task<Usuarios> FindUserByNameAsync(string userName);
    }
}
