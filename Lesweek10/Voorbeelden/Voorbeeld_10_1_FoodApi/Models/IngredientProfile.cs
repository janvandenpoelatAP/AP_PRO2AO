using AutoMapper;
using Voorbeeld_10_01_FoodApi.Entities;

namespace Voorbeeld_10_01_FoodApi.Models;
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