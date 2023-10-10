using Voorbeeld02_HelloCore.Entities;

namespace Voorbeeld02_HelloCore.ViewModels;

public class HomePageViewModel
{
    public string CurrentMessage { get; set; }
    public IEnumerable<Restaurant>Restaurants { get; set; }
}
