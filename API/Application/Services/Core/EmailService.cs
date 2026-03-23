using API.Application.DTOs;
using API.Application.Interfaces;
using API.Domain.Models.Core;
using API.Infrastructure.DAL.Interfaces;
using MailKit.Security;
using MimeKit;
using SmtpClient = MailKit.Net.Smtp.SmtpClient;

namespace API.Application.Services.Core
{
    public class EmailService : IEmailService
    {
        private readonly IEmailDAL _emailDAL;
        private readonly IConfiguration _configuration;
        public EmailService(IEmailDAL emailDAL, IConfiguration configuration)
        {
            _configuration = configuration;
            _emailDAL = emailDAL;
        }

        public async Task<Response> GetEmailConfiguration(string Code)
        {
            try
            {
                var response = new Response();
                var IsExistConfiguration = await _emailDAL.GetEmailConfiguration(Code);
                if (IsExistConfiguration != null)
                {
                    response.IsSuccess = true;
                    response.Message = IsExistConfiguration.ToString();
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task SendEmailAsync(EmailRequestDTO emailRequest)
        {
            var email = new MimeMessage();
            var accountAppPassword = _configuration["Gmail-App-Password"];

            email.From.Add(new MailboxAddress("YourApp", emailRequest.FromEmail));
            email.To.Add(MailboxAddress.Parse(emailRequest.ToEmail));
            email.Subject = emailRequest.Subject;

            email.Body = new TextPart("plain")
            {
                Text = emailRequest.Body
            };

            using var smtp = new SmtpClient();

            await smtp.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

            // Use App Password here
            await smtp.AuthenticateAsync(emailRequest.FromEmail, accountAppPassword);

            await smtp.SendAsync(email);

            await smtp.DisconnectAsync(true);
        }
    }
}
