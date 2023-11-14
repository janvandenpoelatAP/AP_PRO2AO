using System.ComponentModel.DataAnnotations;
using Oefening_05_02_PersonsMVC.Entities;

namespace Oefening_05_02_PersonsMVC.ViewModels;
public class PersonCreateViewModel
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string Address { get; set; }
    public Gender Gender { get; set; }
}
