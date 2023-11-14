using Microsoft.AspNetCore.Mvc;

namespace Voorbeeld_04_01_HelloCore.Controllers;
[Route("[controller]")]
public class AboutController
{
    [HttpGet()]
    public string Phone()
    {
        return "+32 489 50 49 12";
    }
    [HttpGet()]
    [Route("[action]")]
    public string Address()
    {
        return "België";
    }
}
