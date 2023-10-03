using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Voorbeeld01_DIEmailSender;
public class EmailSender : IEmailSender
{
    public void SendEmail(string message)
    {
        using (var smtpClient = new SmtpClient())
        {
            //This will crash since we didn't define an SMTP server
            //smtpClient.Send(new MailMessage { Body = message });
            Console.WriteLine($"Message {message} delivered");
        }
    }
}
