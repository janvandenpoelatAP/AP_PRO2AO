﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Voorbeeld_10_01_FoodApi.Entities;
public class Dish
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [MaxLength(200)]
    public required string Name { get; set; }

    public ICollection<Ingredient> Ingredients { get; set; } = new List<Ingredient>();

    public Dish()
    {
    }

    [SetsRequiredMembers]
    public Dish(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}