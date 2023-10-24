namespace BudgetAplicationApi.Api.Interfaces
{
    public interface IAuthFacade
    {
        Task<bool> VerifyLogin(string password, string userName);
        string CreateJwtToken(string username);
        Task<string> Hash(string password);
    }
}
