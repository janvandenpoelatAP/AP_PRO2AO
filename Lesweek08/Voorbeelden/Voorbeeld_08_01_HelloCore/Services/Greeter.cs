namespace Voorbeeld_08_01_HelloCore.Services;
public interface IGreeter
{
    string GetGreeting();
}
public class Greeter : IGreeter
{
    private readonly IConfiguration configuration;

    public Greeter(IConfiguration configuration)
    {
        this.configuration = configuration;
    }
    public string GetGreeting()
    {
        return configuration["Greeting"];
    }
}
