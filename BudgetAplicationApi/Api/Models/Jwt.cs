namespace BudgetAplicationApi.Api.Models
{
    public class Jwt
    {
        public int Id { get; set; }
        public DateTime CreadoEn { get; set; }
        public DateTime ExpiraEn { get; set; }
        public string Token { get; set; }
        public Usuarios Usuario { get; set; }
    }
}
