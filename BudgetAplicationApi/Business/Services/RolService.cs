using BudgetAplicationApi.Api;
using BudgetAplicationApi.Api.Exceptions;
using BudgetAplicationApi.Api.Interfaces;
using BudgetAplicationApi.Api.Models;
using BudgetAplicationApi.Data.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BudgetAplicationApi.Business.Services
{
    public class RolService : IRolesService
    {
        private readonly DataContext _dbContext;

        public RolService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Rol>> GetAllRolesAsync()
        {
            return await _dbContext.Roles.ToListAsync();
        }

        public async Task<Rol> GetRoleByIdAsync(int roleId)
        {
            return await _dbContext.Roles.FindAsync(roleId);
        }

        public async Task CreateRoleAsync(Rol rol)
        {
            _dbContext.Roles.Add(rol);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateRoleAsync(int roleId, Rol updatedRol)
        {
            var existingRol = await _dbContext.Roles.FindAsync(roleId);
            if (existingRol == null)
            {
                throw new NotFoundException("Role not found");
            }

            existingRol.Descripcion = updatedRol.Descripcion;
            existingRol.Estado = updatedRol.Estado;
            existingRol.Fecha = updatedRol.Fecha;

            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteRoleAsync(int roleId)
        {
            var rol = await _dbContext.Roles.FindAsync(roleId);
            if (rol != null)
            {
                _dbContext.Roles.Remove(rol);
                await _dbContext.SaveChangesAsync();
            }
        }

        public List<RolesEnum> GetRolesByUserNameAsync(string username)
        {
            var result = new List<Rol>(_dbContext.Usuarios
                .Include(x => x.Roles)
                .Where(x => x.Nombre == username)
                .Select(x => x.Roles)
                .FirstOrDefault());
            return result
                .Select(x => x.Descripcion)
                .ToList();
        }
    }
}