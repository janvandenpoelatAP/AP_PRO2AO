using Voorbeeld05_HelloCore.Entities;

namespace Voorbeeld05_HelloCore.ViewModels;

public class HomePageViewModel
{
    public string CurrentMessage { get; set; }
    public IEnumerable<Restaurant>Restaurants { get; set; }
}
