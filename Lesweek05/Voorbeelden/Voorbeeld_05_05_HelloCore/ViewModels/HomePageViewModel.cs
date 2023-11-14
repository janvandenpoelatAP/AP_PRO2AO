using Voorbeeld_05_05_HelloCore.Entities;

namespace Voorbeeld_05_05_HelloCore.ViewModels;
public class HomePageViewModel
{
    public string CurrentMessage { get; set; }
    public IEnumerable<Restaurant>Restaurants { get; set; }
}
