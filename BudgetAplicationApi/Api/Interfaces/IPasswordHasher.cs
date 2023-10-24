namespace BudgetAplicationApi.Api.Interfaces
{
    public interface IPasswordHasher
    {
        string Hash(string password);
        bool Verify(string passwordhash, string inputpassword);
    }
}
