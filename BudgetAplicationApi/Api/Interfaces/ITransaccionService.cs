using BudgetAplicationApi.Api.Models;

namespace BudgetAplicationApi.Api.Interfaces
{
    public interface ITransaccionService
    {
        Transaccion CreateTransaccion(Transaccion compania);
        Transaccion GetTransaccion(int id);
        IEnumerable<Transaccion> GetAllTransaccions();
        Transaccion UpdateTransaccion(Transaccion compania);
        void DeleteTransaccion(int id);
    }
}
