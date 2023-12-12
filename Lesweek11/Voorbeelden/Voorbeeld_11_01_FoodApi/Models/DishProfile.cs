﻿using AutoMapper;
using Voorbeeld_11_01_FoodApi.Entities;

namespace Voorbeeld_11_01_FoodApi.Models;
public class DishProfile : Profile
{
    public DishProfile()
    {
        CreateMap<Dish, DishDto>();
        CreateMap<DishForCreationDto, Dish>();
        CreateMap<DishForUpdateDto, Dish>();
    }
}