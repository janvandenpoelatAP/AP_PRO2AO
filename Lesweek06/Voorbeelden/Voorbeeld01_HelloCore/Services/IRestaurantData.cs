using Voorbeeld_06_01_HelloCore.Entities;

namespace Voorbeeld_06_01_HelloCore.Services
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