using Voorbeeld02_HelloCore.Entities;

namespace Voorbeeld02_HelloCore.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        void Add(Restaurant restaurant);
    }
}