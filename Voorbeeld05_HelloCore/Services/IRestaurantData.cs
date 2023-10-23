﻿using Voorbeeld05_HelloCore.Entities;

namespace Voorbeeld05_HelloCore.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetAll();
        Restaurant Get(int id);
        void Add(Restaurant restaurant);
    }
}