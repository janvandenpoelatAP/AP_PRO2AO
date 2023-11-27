using Voorbeeld_08_01_HelloCore.Entities;

namespace Voorbeeld_08_01_HelloCore.ViewModels;

public class HomePageViewModel
{
    public string CurrentMessage { get; set; }
    public IEnumerable<Restaurant>Restaurants { get; set; }
}
