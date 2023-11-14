using Microsoft.AspNetCore.Mvc;

namespace Voorbeeld_04_02_HelloCore.Controllers;
public class AboutController : Controller
{
    public string Phone()
    {
        return "+32 489 50 49 12";
    }
    public string Address()
    {
        return "België";
    }
}
