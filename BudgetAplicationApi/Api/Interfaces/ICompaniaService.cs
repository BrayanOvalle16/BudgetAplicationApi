using BudgetAplicationApi.Api.Models;

namespace BudgetAplicationApi.Api.Interfaces
{
    public interface ICompaniaService
    {
        Compania CreateCompania(Compania compania);
        Compania GetCompania(int id);
        IEnumerable<Compania> GetAllCompanias();
        Compania UpdateCompania(Compania compania);
        void DeleteCompania(int id);
    }
}
