using Voorbeeld_04_02_HelloCore.Entities;

namespace Voorbeeld_04_02_HelloCore.Services;
public interface IRestaurantData
{
    IEnumerable<Restaurant> GetAll();
    Restaurant Get(int id);
}