using BudgetAplicationApi.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetAplicationApi.Data.ApplicationDbContext
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Compania> Companias { get; set; }
        public DbSet<Contabilidad> Contabilidades { get; set; }
        public DbSet<Jwt> Jwt { get; set; }
        public DbSet<Movimiento> Movimientos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Transaccion> Transacciones { get; set; }
        public DbSet<Usuarios> Usuarios { get; set; }
    }
}
