using Oefening02_PersonsMVC.Entities;
using System.ComponentModel.DataAnnotations;

namespace OefeningPersonsMVC.ViewModels;

public class PersonCreateViewModel
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    public string Address { get; set; }
    public Gender Gender { get; set; }
}
