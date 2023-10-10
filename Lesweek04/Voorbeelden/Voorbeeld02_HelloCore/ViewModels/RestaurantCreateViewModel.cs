using Voorbeeld02_HelloCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace Voorbeeld02_HelloCore.ViewModels;

public class RestaurantCreateViewModel
{
    [Required, MaxLength(80)]
    public string Name { get; set; }
    public CuisineType CuisineType { get; set; }
}
