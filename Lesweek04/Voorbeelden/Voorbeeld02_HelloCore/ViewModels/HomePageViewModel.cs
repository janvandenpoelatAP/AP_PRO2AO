using Voorbeeld_04_02_HelloCore.Entities;

namespace Voorbeeld_04_02_HelloCore.ViewModels;
public class HomePageViewModel
{
    public string CurrentMessage { get; set; }
    public IEnumerable<Restaurant>Restaurants { get; set; }
}
