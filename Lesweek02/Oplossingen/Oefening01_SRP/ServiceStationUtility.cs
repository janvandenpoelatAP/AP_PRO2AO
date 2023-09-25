using Oefening01_SRP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oefening01_SRP;
public class ServiceStationUtility : IGateUtility
{
    public void OpenGate()
    {
        //Open the shop if the time is later than 9 AM
    }
    public void CloseGate()
    {
        //Close the shop if the time has crossed 6PM
    }
}
