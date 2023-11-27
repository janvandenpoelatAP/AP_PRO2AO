using AutoMapper;
using Voorbeeld_09_1_FoodApi.Entities;

namespace Voorbeeld_09_1_FoodApi.Models;
public class IngredientProfile : Profile
{
    public IngredientProfile()
    {
        CreateMap<Ingredient, IngredientDto>()
            .ForMember(
                d => d.DishId,
                o => o.MapFrom(s => s.Dishes.First().Id));
    }
}