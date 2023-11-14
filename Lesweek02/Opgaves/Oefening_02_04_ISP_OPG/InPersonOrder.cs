namespace Oefening_02_04_ISP_OPG;
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