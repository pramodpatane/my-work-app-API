using API.Models.Core;

namespace API.Services.Interfaces
{
    public interface IEmailService
    {
        public Task<Response> GetEmailConfiguration(string Code);

        Task SendEmailAsync(EmailRequestDTO emailRequest);
    }
}
