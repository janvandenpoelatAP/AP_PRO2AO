using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening04_ISP_OPG;
public class InpersionOrder : IOrder
{
    public void Purchase()
    {
        //Do purchase
    }
    public void ProcessCreditCard()
    {
        //Not required for inperson purchase
        throw new NotImplementedException();
    }
}