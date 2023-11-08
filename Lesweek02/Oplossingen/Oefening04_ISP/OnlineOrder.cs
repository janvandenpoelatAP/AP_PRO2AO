namespace Oefening_02_04_ISP
{
    public class OnlineOrder : IOrder, IOnlineOrder
    {
        public void Purchase()
        {
            //Do purchase
        }
        public void ProcessCreditCard()
        {
            //process through credit card
        }
    }
}
