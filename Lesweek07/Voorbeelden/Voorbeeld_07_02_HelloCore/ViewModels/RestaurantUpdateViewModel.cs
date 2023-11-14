using System.ComponentModel.DataAnnotations;
using Voorbeeld_07_02_HelloCore.Entities;

namespace Voorbeeld_07_02_HelloCore.ViewModels;
public class RestaurantUpdateViewModel
{
    [Required, MaxLength(80)]
    public string Name { get; set; }
    public CuisineType CuisineType { get; set; }
}
