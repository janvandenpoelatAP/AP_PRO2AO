using System.ComponentModel.DataAnnotations;
using Voorbeeld_08_01_HelloCore.Entities;

namespace Voorbeeld_08_01_HelloCore.ViewModels;
public class RestaurantUpdateViewModel
{
    [Required, MaxLength(80)]
    public string Name { get; set; }
    public CuisineType CuisineType { get; set; }
}
