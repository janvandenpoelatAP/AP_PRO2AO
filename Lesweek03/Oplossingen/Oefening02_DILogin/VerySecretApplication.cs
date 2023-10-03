namespace Oefening02_DILogin;

public class VerySecretApplication
{
    private readonly ILogin login;

    public VerySecretApplication(ILogin login)
    {
        this.login = login;
    }

    public void Start()
    {
        Console.WriteLine("Username:");
        var username = Console.ReadLine();
        Console.WriteLine("Password:");
        var password = Console.ReadLine();
        var loggedIn = login.Login(username, password);
        if (!loggedIn)
        {
            Console.WriteLine("Invalid username/password");
        }
        Console.WriteLine("Secret program started");
    }
}
