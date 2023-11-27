using AutoMapper;
using Voorbeeld_09_1_FoodApi.Entities;

namespace Voorbeeld_09_1_FoodApi.Models;
public class DishProfile : Profile
{
    public DishProfile()
    {
        CreateMap<Dish, DishDto>();
    }
}
