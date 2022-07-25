using MailKit.Net.Smtp;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Brajici.Models
{
    public class EmailService : IEmailService
    {

        public void Send(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(emailMessage.Subject ,emailMessage.FromAddress));
            message.To.Add(new MailboxAddress("Brajici Sajt", "sajtbrajici@gmail.com"));
            message.Subject = emailMessage.Subject;
            message.Body = new TextPart("plain")
            {
                Text = emailMessage.Content+Environment.NewLine+Environment.NewLine+emailMessage.FromAddress
            };
            using (var emailClient = new SmtpClient())
            {
                emailClient.Connect("smtp.gmail.com", 587, false);

                emailClient.AuthenticationMechanisms.Remove("XOAUTH2");
                emailClient.Authenticate("sajtbrajici@gmail.com", "pobori1965*");

                emailClient.Send(message);

                emailClient.Disconnect(true);
            }
        }
    }
}
