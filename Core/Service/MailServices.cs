using Domain.Models;
using Microsoft.Extensions.Options;
using MimeKit;
using ServiceAbstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class MailServices(IOptions<MailSetting> options1) : IMailServices
    {
        public async Task SendEmailAsync(Email email)
        {
            var mail = new MimeMessage();
            mail.Subject = email.Subject;
            mail.From.Add(new MailboxAddress(options1.Value.DisplayName, options1.Value.Email));
            mail.To.Add(MailboxAddress.Parse(email.To));
            var builder = new BodyBuilder();
            builder.HtmlBody = email.Body;
            mail.Body = builder.ToMessageBody();
            using var smtp = new MailKit.Net.Smtp.SmtpClient();
            smtp.Connect(options1.Value.Host, options1.Value.Port, MailKit.Security.SecureSocketOptions.StartTls);
            smtp.Authenticate(options1.Value.Email, options1.Value.Password);
            smtp.Send(mail);
        }
    }
}
