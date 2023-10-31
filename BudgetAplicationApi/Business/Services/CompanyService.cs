using BudgetAplicationApi.Api.Exceptions;
using BudgetAplicationApi.Api.Interfaces;
using BudgetAplicationApi.Api.Models;
using BudgetAplicationApi.Data.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace BudgetAplicationApi.Business.Services
{
    public class CompaniaService : ICompaniaService
    {
        private readonly DataContext _context; 

        public CompaniaService(DataContext context)
        {
            _context = context;
        }

        public Compania CreateCompania(Compania compania)
        {
            _context.Companias.Add(compania);
            _context.SaveChanges();
            return compania;
        }

        public Compania GetCompania(int id)
        {
            return _context.Companias.FirstOrDefault(c => c.ID == id && c.Estado);
        }

        public IEnumerable<Compania> GetAllCompanias()
        {
            return _context.Companias
                .Where(x => x.Estado)
                .ToList();
        }

        public Compania UpdateCompania(Compania compania)
        {
            _context.Companias.Update(compania);
            _context.SaveChanges();
            return compania;
        }

        public void DeleteCompania(int id)
        {
            var compania = _context.Companias.FirstOrDefault(c => c.ID == id);
            if (compania != null)
            {
                compania.Estado = false;
                _context.SaveChanges();
            }
        }
    }
}
