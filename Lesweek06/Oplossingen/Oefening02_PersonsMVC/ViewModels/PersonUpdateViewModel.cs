using Oefening03_PersonsMVC.Entities;
using System.ComponentModel.DataAnnotations;

namespace Oefening03_PersonsMVC.ViewModels;

public class PersonUpdateViewModel
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string Address { get; set; }
    public Gender Gender { get; set; }
}
