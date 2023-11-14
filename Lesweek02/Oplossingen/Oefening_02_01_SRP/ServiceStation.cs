namespace Oefening_02_01_SRP;
public class ServiceStation
{
    IGateUtility gateUtility;

    public ServiceStation(IGateUtility gateUtility)
    {
        this.gateUtility = gateUtility;
    }
    public void OpenForService()
    {
        gateUtility.OpenGate();
    }
    public void DoService()
    {
        //Check if service station is opened and then
        //complete the vehicle service
    }
    public void CloseForDay()
    {
        gateUtility.CloseGate();
    }
}