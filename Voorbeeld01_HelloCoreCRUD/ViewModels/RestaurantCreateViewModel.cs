using Voorbeeld06_HelloCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace Voorbeeld06_HelloCore.ViewModels;

public class RestaurantCreateViewModel
{
    [Required, MaxLength(80)]
    public string Name { get; set; }
    public CuisineType CuisineType { get; set; }
}
