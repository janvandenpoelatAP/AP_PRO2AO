using AutoMapper;
using Voorbeeld_09_01_FoodApi.Entities;

namespace Voorbeeld_09_01_FoodApi.Models;
public class DishProfile : Profile
{
    public DishProfile()
    {
        CreateMap<Dish, DishDto>();
    }
}
