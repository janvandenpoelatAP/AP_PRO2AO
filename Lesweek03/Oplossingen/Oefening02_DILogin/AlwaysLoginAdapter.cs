namespace Oefening02_DILogin;
public class AlwaysLoginAdapter : ILogin
{
    public bool Login(string username, string password)
    {
        return true;
    }
}
