using BudgetAplicationApi.Api.Models;

namespace BudgetAplicationApi.Api.Interfaces
{
    public interface IContabilidadService
    {
        Contabilidad CreateContabilidad(Contabilidad compania);
        Contabilidad GetContabilidad(int id);
        IEnumerable<Contabilidad> GetAllContabilidads();
        Contabilidad UpdateContabilidad(Contabilidad compania);
        void DeleteContabilidad(int id);
    }
}
