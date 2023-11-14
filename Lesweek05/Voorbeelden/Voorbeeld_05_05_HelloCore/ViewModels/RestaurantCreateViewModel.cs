using Voorbeeld_05_05_HelloCore.Entities;
using System.ComponentModel.DataAnnotations;

namespace Voorbeeld_05_05_HelloCore.ViewModels;
public class RestaurantCreateViewModel
{
    [Required, MaxLength(80)]
    public string Name { get; set; }
    public CuisineType CuisineType { get; set; }
}
