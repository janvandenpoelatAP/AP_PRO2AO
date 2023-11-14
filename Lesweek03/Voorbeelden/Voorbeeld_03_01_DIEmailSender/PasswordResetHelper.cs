namespace Voorbeeld_03_01_DIEmailSender;
public class PasswordResetHelper
{
    private readonly IEmailSender emailSender;

    public PasswordResetHelper(IEmailSender emailSender)
    {
        this.emailSender = emailSender;
    }

    public void ResetPassword()
    {
        var newPassword = Guid.NewGuid().ToString();
        emailSender.SendEmail(newPassword);
    }
}
