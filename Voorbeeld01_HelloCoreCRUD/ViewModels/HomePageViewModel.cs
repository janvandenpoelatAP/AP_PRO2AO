using Voorbeeld06_HelloCore.Entities;

namespace Voorbeeld06_HelloCore.ViewModels;

public class HomePageViewModel
{
    public string CurrentMessage { get; set; }
    public IEnumerable<Restaurant>Restaurants { get; set; }
}
