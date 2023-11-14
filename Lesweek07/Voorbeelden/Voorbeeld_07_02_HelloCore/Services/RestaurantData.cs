using HelloCore.Entities;
using   Voorbeeld_07_02_HelloCore.Entities;

namespace Voorbeeld_07_02_HelloCore.Services;
public class RestaurantDataInMemory : IRestaurantData
{
    private static List<Restaurant> restaurants;

    static RestaurantDataInMemory()
    {
        restaurants = new List<Restaurant>()
        {
            new Restaurant() {Id = 1, Name = "My Resto" },
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
    public void Add(Restaurant restaurant)
    {
        restaurant.Id = restaurants.Max(x => x.Id) + 1;
        restaurants.Add(restaurant);
    }
    public void Delete(Restaurant restaurant)
    {
        restaurants.Remove(restaurant);
    }
    public void Update(Restaurant restaurant)
    {
        var restaurantUpdate = Get(restaurant.Id);
        restaurantUpdate.Name = restaurant.Name;
        restaurantUpdate.CuisineType = restaurant.CuisineType;
    }
}
public class RestaurantDataSQL : IRestaurantData
{
    private HelloCoreDbContext context;

    public RestaurantDataSQL(HelloCoreDbContext context)
    {
        this.context = context;
    }

    public IEnumerable<Restaurant> GetAll()
    {
        return context.Restaurants;
    }
    public Restaurant Get(int id)
    {
        return context.Restaurants.FirstOrDefault(x => x.Id == id);
    }
    public void Add(Restaurant restaurant)
    {
        context.Restaurants.Add(restaurant);
        context.SaveChanges();
    }
    public void Delete(Restaurant restaurant)
    {
        var toDelete = Get(restaurant.Id);
        context.Restaurants.Remove(toDelete);
        context.SaveChanges();
    }
    public void Update(Restaurant restaurant)
    {
        var oldRestaurant = Get(restaurant.Id);
        oldRestaurant.Name = restaurant.Name;
        oldRestaurant.CuisineType = restaurant.CuisineType;
        context.SaveChanges();
    }
}

