using Voorbeeld_07_02_HelloCore.Entities;

namespace Voorbeeld_07_02_HelloCore.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        void Add(Restaurant restaurant);
        void Delete(Restaurant restaurant);
        void Update(Restaurant restaurant);
    }
}