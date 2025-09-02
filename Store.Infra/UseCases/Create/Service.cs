using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SendGrid;
using SendGrid.Helpers.Mail;
using Store.Domain;
using Store.Domain.Entities;
using Store.Domain.UseCases.Create.Contracts;

namespace Store.Infra.UseCases.Create
{
    public class Service : IService
    {
        public async Task SendEmailAsync(User user, CancellationToken cancellationToken)
        {
            var client = new SendGridClient(Configuration.SendGrid.ApiKey);
            var from = new EmailAddress(Configuration.Email.DefaultFromEmail, Configuration.Email.DefaultFromName);
            var subject = "Verify Your Email";
            var to = new EmailAddress(user.Email.Address, user.Name);
            var content = $"Codigo {user.Email.Verification.Code}";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, content, content);
            await client.SendEmailAsync(msg, cancellationToken);
        }
    }
}