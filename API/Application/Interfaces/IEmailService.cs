using API.Application.DTOs;
using API.Domain.Entities.Core;

namespace API.Application.Interfaces
{
    public interface IEmailService
    {
        public Task<Response> GetEmailConfiguration(string Code);

        Task SendEmailAsync(EmailRequestDTO emailRequest);
    }
}
