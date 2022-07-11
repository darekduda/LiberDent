using Microsoft.Extensions.Options;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LiberDent.PortalWWW.Services
{
    public class EmailSender : IEmailSender
    {
        public EmailSender(IOptions<EmailAuthOptions> optionsAccessor)
        {
            Options = optionsAccessor.Value;
        }

        public EmailAuthOptions Options { get; } //set only via Secret Manager

        public Task SendEmailAsync(List<string> emails, string subject, string message)
        {

            return Execute(Environment.GetEnvironmentVariable("KeyStudentLiberDent"), subject, message, emails);
        }

        public Task Execute(string apiKey, string subject, string message, List<string> emails)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("xXdudaXx@gmail.com", "Duda"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            foreach (var email in emails)
            {
                msg.AddTo(new EmailAddress(email));
            }

            Task response = client.SendEmailAsync(msg);
            return response;
        }

        public Task SendEmailAsync(string emails, string subject, string message)
        {
            return Execute(Environment.GetEnvironmentVariable("KeyStudentLiberDent"), subject, message, emails);
        }

        public Task Execute(string apiKey, string subject, string message, string email)
        {
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("xXdudaXx@gmail.com", "Duda"),
                Subject = subject,
                PlainTextContent = message,
                HtmlContent = message
            };

            
            msg.AddTo(new EmailAddress(email));

            Task response = client.SendEmailAsync(msg);
            return response;
        }
    }
}
