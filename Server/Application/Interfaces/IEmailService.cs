using Server.Application.DTOs;
using Server.Domain.Entities.Core;

namespace Server.Application.Interfaces
{
    public interface IEmailService
    {
        public Task<Response> GetEmailConfiguration(string Code);

        Task SendEmailAsync(EmailRequestDTO emailRequest);
    }
}
