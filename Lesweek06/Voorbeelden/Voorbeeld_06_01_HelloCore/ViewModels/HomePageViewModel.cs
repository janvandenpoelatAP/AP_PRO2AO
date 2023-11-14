using Voorbeeld_06_01_HelloCore.Entities;

namespace Voorbeeld_06_01_HelloCore.ViewModels;

public class HomePageViewModel
{
    public string CurrentMessage { get; set; }
    public IEnumerable<Restaurant>Restaurants { get; set; }
}
