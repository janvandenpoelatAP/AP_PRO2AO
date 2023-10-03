using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorbeeld01_DIEmailSender;
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
