using BudgetAplicationApi.Api.Interfaces;
using BudgetAplicationApi.Api.Models;
using BudgetAplicationApi.Data.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace BudgetAplicationApi.Business.Services
{
    public class TransaccionService : ITransaccionService
    {
        private readonly DataContext _context;

        public TransaccionService(DataContext context)
        {
            _context = context;
        }

        public Transaccion CreateTransaccion(Transaccion compania)
        {
            _context.Transacciones.Add(compania);
            _context.SaveChanges();
            return compania;
        }

        public Transaccion GetTransaccion(int id)
        {
            return _context.Transacciones
                .Include(x => x.Movimientos)
                .ThenInclude(x => x.Contabilidad)
                .Include(x => x.Compania)
                .Include(x => x.Usuario)
                .FirstOrDefault(c => c.ID == id && c.Estado);
        }

        public IEnumerable<Transaccion> GetAllTransaccions()
        {
            return _context.Transacciones
                .Include(x => x.Movimientos)
                .ThenInclude(x => x.Contabilidad)
                .Include(x => x.Compania)
                .Include(x => x.Usuario)
                .Where(x => x.Estado)
                .ToList();
        }

        public Transaccion UpdateTransaccion(Transaccion compania)
        {
            _context.Transacciones.Update(compania);
            _context.SaveChanges();
            return compania;
        }

        public void DeleteTransaccion(int id)
        {
            var compania = _context.Transacciones.FirstOrDefault(c => c.ID == id);
            if (compania != null)
            {
                compania.Estado = false;
                _context.SaveChanges();
            }
        }
    }
}
