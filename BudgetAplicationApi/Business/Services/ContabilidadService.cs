using BudgetAplicationApi.Api.Interfaces;
using BudgetAplicationApi.Api.Models;
using BudgetAplicationApi.Data.ApplicationDbContext;

namespace BudgetAplicationApi.Business.Services
{
    public class ContabilidadService : IContabilidadService
    {
        private readonly DataContext _context;

        public ContabilidadService(DataContext context)
        {
            _context = context;
        }

        public Contabilidad CreateContabilidad(Contabilidad compania)
        {
            _context.Contabilidades.Add(compania);
            _context.SaveChanges();
            return compania;
        }

        public Contabilidad GetContabilidad(int id)
        {
            return _context.Contabilidades.FirstOrDefault(c => c.Id == id && c.Estado);
        }

        public IEnumerable<Contabilidad> GetAllContabilidads()
        {
            return _context.Contabilidades
                .Where(x => x.Estado)
                .ToList();
        }

        public Contabilidad UpdateContabilidad(Contabilidad compania)
        {
            _context.Contabilidades.Update(compania);
            _context.SaveChanges();
            return compania;
        }

        public void DeleteContabilidad(int id)
        {
            var compania = _context.Contabilidades.FirstOrDefault(c => c.Id == id);
            if (compania != null)
            {
                compania.Estado = false;
                _context.SaveChanges();
            }
        }
    }
}
