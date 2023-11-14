namespace Voorbeeld_03_01_DIEmailSender;
public class EmailSender : IEmailSender
{
    public void SendEmail(string message)
    {
        using (var smtpClient = new HttpClient())
        {
            //This will crash since we didn't define an SMTP server
            //smtpClient.Send(new MailMessage { Body = message });
            Console.WriteLine($"Message {message} delivered");
        }
    }
}
