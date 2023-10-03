namespace Oefening02_DILogin;
public class HardCodedLoginAdapter : ILogin
{
    public bool Login(string username, string password)
    {
        return username == "Admin" && password == "abc123";
    }
}
