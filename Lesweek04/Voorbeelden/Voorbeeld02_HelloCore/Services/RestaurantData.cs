using Voorbeeld_04_02_HelloCore.Entities;

namespace Voorbeeld_04_02_HelloCore.Services;
public class RestaurantDataInMemory : IRestaurantData
{
    private static List<Restaurant> restaurants;

    static RestaurantDataInMemory()
    {
        restaurants = new List<Restaurant>()
        {
            new Restaurant() {Id = 1, Name =    "My Resto" },
            new Restaurant() {Id = 2, Name = "Funny Pizza"},
            new Restaurant() {Id = 3, Name = "Crazy Burger"}
        };
    }
    public IEnumerable<Restaurant> GetAll()
    {
        return restaurants;
    }
    public Restaurant Get(int id)
    {
        return restaurants.FirstOrDefault(x => x.Id == id);
    }
}
