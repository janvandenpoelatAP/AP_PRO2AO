using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voorbeeld01_DIEmailSender;
public interface IEmailSender
{
    void SendEmail(string message);
}