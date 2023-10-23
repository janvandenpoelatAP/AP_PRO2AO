using Microsoft.AspNetCore.Mvc;

namespace HelloCore.Controllers;

public class HomeController
{
    public string Index()
    {
        return $"Het is momenteel {DateTime.Now}";
    }
}
