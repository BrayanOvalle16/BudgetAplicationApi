using BudgetAplicationApi.Api.Models;

namespace BudgetAplicationApi.Api.Interfaces
{
    public interface IRolesService
    {
        Task<IEnumerable<Rol>> GetAllRolesAsync();
        Task<Rol> GetRoleByIdAsync(int roleId);
        Task CreateRoleAsync(Rol rol);
        Task UpdateRoleAsync(int roleId, Rol updatedRol);
        Task DeleteRoleAsync(int roleId);
        List<RolesEnum> GetRolesByUserNameAsync(string username);
    }
}
