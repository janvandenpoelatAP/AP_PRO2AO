namespace Oefening_04_01_ASPMVC.Controllers;
public class HomeController
{
    public string Index()
    {
        return $"Het is momenteel {DateTime.Now}";
    }
}
