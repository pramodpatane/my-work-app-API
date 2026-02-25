using API.Models.Core;

namespace API.DAL.Interfaces
{
    public interface IEmailDAL
    {
        public Task<string> GetEmailConfiguration(string Code);
    }
}
