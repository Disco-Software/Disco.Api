using Disco.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Disco.BLL.Services
{
    public class EmailService : IEmailService
    {
        public async Task SendToEmailAsync(string to, string subject, bool isHTML)
        {
            var htmlStream = @"../Disco.Server/EmailTemplate/ConfirmEmail.html";

            var streamReader = new StreamReader(htmlStream);
            var str = await streamReader.ReadToEndAsync();

            MailMessage ms = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            ms.From = new MailAddress("korchevskyy.s@inprimex.com");
            ms.To.Add(new MailAddress(to));
            ms.Subject = subject;
            ms.IsBodyHtml = isHTML; //to make message body as html  
            ms.Body = str.ToString();
            smtp.Port = 587;
           smtp.Host = "smtp.gmail.com"; //for gmail host  
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("korchevskyy.s@inprimex.com", "cJM23H87");
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Send(ms);
        }
    }
}
