using LifeBank.Application.Common.Interfaces;
using LifeBank.Application.Common.Models;
using Microsoft.Extensions.Configuration;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace LifeBank.Infrastructure
{
    public class MailService : IMailService
    {
        private readonly IConfiguration configuration;

        public MailService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<string> SendAsync(MessageDto message)
        {
            var apiKey = configuration["SendGridAPIKey"];
            var client = new SendGridClient(apiKey);

            var emailMessage = new SendGridMessage()
            {
                From = new EmailAddress(message.From),
                ReplyTo = new EmailAddress(message.To),
                Subject = message.Subject,
                HtmlContent = message.Body,
                PlainTextContent = message.Body
            };

            var response = await client.SendEmailAsync(emailMessage);
            return response.StatusCode.ToString();
        }
    }
}
