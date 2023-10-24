using BudgetAplicationApi.Api.Exceptions;
using BudgetAplicationApi.Api.Interfaces;
using BudgetAplicationApi.Api.Models;
using BudgetAplicationApi.Data.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace BudgetAplicationApi.Business.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly DataContext _dbContext;

        public UsuariosService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Usuarios>> GetAllUsuariosAsync()
        {
            return await _dbContext.Usuarios
                .Where(x => x.Estado)
                .ToListAsync();
        }

        public async Task<Usuarios> GetUsuarioByIdAsync(int usuarioId)
        {
            return await _dbContext.Usuarios
                .Where(x => x.Estado)
                .Where(x => x.ID == usuarioId)
                .FirstOrDefaultAsync();
        }

        public async Task CreateUsuarioAsync(Usuarios usuario)
        {
            var rol = await _dbContext.Roles
                .Where(x => x.Descripcion == Api.RolesEnum.Contador)
                .FirstOrDefaultAsync();
            usuario.Roles = new List<Rol>();
            usuario.Roles.Add(rol);
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUsuarioAsync(int usuarioId, Usuarios updatedUsuario)
        {
            var existingUsuario = await _dbContext.Usuarios             
                .Where(x => x.Estado)
                .Where(x => x.ID == usuarioId)
                .FirstOrDefaultAsync();
            if (existingUsuario == null)
            {
                throw new NotFoundException("Usuario not found");
            }

            existingUsuario.Nombre = updatedUsuario.Nombre;
            existingUsuario.CorreoElectronico = updatedUsuario.CorreoElectronico;
            existingUsuario.Contrasena = updatedUsuario.Contrasena;
            existingUsuario.NumeroIdentificacion = updatedUsuario.NumeroIdentificacion;
            existingUsuario.Fecha = updatedUsuario.Fecha;
            existingUsuario.Estado = updatedUsuario.Estado;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteUsuarioAsync(int usuarioId)
        {
            var usuario = await _dbContext.Usuarios.Where(x => x.Estado)
                .Where(x => x.ID == usuarioId)
                .FirstOrDefaultAsync();
            if (usuario != null)
            {
                usuario.Estado = false;
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Usuarios> FindUserByNameAsync(string userName)
        {
            return await _dbContext.Usuarios
                    .Where(x => x.Nombre == userName)
                    .Where(x => x.Estado)
                    .FirstOrDefaultAsync();
        }
    }
}
