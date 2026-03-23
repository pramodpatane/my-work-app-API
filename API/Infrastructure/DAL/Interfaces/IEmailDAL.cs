namespace API.Infrastructure.DAL.Interfaces
{
    public interface IEmailDAL
    {
        public Task<string> GetEmailConfiguration(string Code);
    }
}
