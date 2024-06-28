using Application.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Application.Services
{
    public class GeneralEmailService : InterEmailService
    {
        private readonly IConfiguration _configuration;

        public GeneralEmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task SendEmailAsync(string to, string subject, string body)
        {
            var smtpConfig = _configuration.GetSection("Smtp");

            var smtpClient = new SmtpClient(smtpConfig["Host"])
            {
                Port = int.Parse(smtpConfig["Port"]),
                Credentials = new NetworkCredential(smtpConfig["Username"], smtpConfig["Password"]),
                EnableSsl = bool.Parse(smtpConfig["EnableSsl"])
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress(smtpConfig["Username"]),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(to);

            try
            {
                await smtpClient.SendMailAsync(mailMessage);
            }
            catch (Exception ex)
            {
                // Log or handle the error
                throw new Exception("Failed to send email", ex);
            }
        }
    }
}
