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
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuarios> GetUsuarioByIdAsync(int usuarioId)
        {
            return await _dbContext.Usuarios.FindAsync(usuarioId);
        }

        public async Task CreateUsuarioAsync(Usuarios usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUsuarioAsync(int usuarioId, Usuarios updatedUsuario)
        {
            var existingUsuario = await _dbContext.Usuarios.FindAsync(usuarioId);
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
            var usuario = await _dbContext.Usuarios.FindAsync(usuarioId);
            if (usuario != null)
            {
                _dbContext.Usuarios.Remove(usuario);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Usuarios> FindUserByNameAsync(string userName)
        {
            return await _dbContext.Usuarios
                    .Where(x => x.Nombre == userName)
                    .FirstOrDefaultAsync();
        }
    }
}
