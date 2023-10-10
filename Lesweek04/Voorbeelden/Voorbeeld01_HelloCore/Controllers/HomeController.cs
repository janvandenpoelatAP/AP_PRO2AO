using Microsoft.AspNetCore.Mvc;

namespace Voorbeeld01_HelloCore.Controllers;

public class HomeController
{
    public string Index()
    {
        return "Hello from the HomeController";
    }
}
