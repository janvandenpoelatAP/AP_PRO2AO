using Microsoft.AspNetCore.Mvc;
using Oefening02_PersonsMVC.Entities;
using Oefening02_PersonsMVC.Services;
using OefeningPersonsMVC.ViewModels;

namespace Oefening02_PersonsMVC.Controllers;

public class HomeController : Controller
{
    private IPersonData personData;

    public HomeController(IPersonData personData)
    {
        this.personData = personData;
    }

    public IActionResult Index()
    {
        var model = personData.GetAll();
        return Ok(model);
    }

    public IActionResult Details(long id)
    {
        var model = personData.Get(id);
        if (model == null)
        {
            return NotFound();
        }
        return Ok(model);
    }

    [HttpPost]
    public IActionResult Create([FromBody] PersonCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var newPerson = new Person
        {
            FirstName = model.FirstName,
            LastName = model.LastName,
            Address = model.Address,
            Gender = model.Gender
        };
        newPerson = personData.Add(newPerson);
        return CreatedAtAction(nameof(Details), new { id = newPerson.Id }, newPerson);
    }
}