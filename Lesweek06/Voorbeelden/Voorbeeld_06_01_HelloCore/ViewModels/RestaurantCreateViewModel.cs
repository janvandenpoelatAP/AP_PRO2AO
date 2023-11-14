using System.ComponentModel.DataAnnotations;
using Voorbeeld_06_01_HelloCore.Entities;

namespace Voorbeeld_06_01_HelloCore.ViewModels;
public class RestaurantCreateViewModel
{
    [Required, MaxLength(80)]
    public string Name { get; set; }
    public CuisineType CuisineType { get; set; }
}
