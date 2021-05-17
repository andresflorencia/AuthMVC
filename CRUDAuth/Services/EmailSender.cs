using Microsoft.AspNetCore.Identity.UI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace CRUDAuth.Services
{
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            using(var message = new MailMessage())
            {
                message.To.Add(new MailAddress(email,email));
                message.From = new MailAddress("andres280295@gmail.com", "CRUD");
                message.Subject = subject;
                message.Body = htmlMessage;
                message.IsBodyHtml = true;

                using(var client = new SmtpClient("smtp.gmail.com", 587))
                {
                    client.Port = 587;
                    client.UseDefaultCredentials = false;
                    client.Credentials = new NetworkCredential("andres280295@gmail.com", "pinejo 95");
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }
            return Task.CompletedTask;
        }
    }
}
