using EMarketAlex2.Core.Aplication.Dtos.Email;
using EMarketAlex2.Core.Aplication.Interfaces.Services;
using EMarketAlex2.Core.Domain.Settings;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarketAlex2.Infraestructure.Shared.Services
{
   public class EmailService: IEmailService
    {
        private MailSettings _mailSettings { get; }

        public EmailService (IOptions <MailSettings> mailSettings)
        {
            _mailSettings = mailSettings.Value;
        }

        public async Task SendAsync(EmailRequest rq)
        {
            try
            {
                MimeMessage email = new();

                email.Sender = MailboxAddress.Parse(_mailSettings.DisplayName + " <" + _mailSettings.EmailFrom + ">");
                email.To.Add(MailboxAddress.Parse(rq.To));
                email.Subject = rq.Subject;
                BodyBuilder builder = new();
                builder.HtmlBody = rq.Body;
                email.Body = builder.ToMessageBody();

                using SmtpClient smtp = new();

                
                smtp.Connect(_mailSettings.SmtpHost, _mailSettings.SmtpPort, MailKit.Security.SecureSocketOptions.StartTls);

                smtp.Authenticate(_mailSettings.SmtpUser, _mailSettings.SmtpPass);

                await smtp.SendAsync(email);

                smtp.Disconnect(true);


            }
            catch(Exception ex)
            {


            }
        
        }


    }
}
