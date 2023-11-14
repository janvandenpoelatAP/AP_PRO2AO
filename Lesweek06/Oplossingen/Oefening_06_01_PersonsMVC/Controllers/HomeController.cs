using Microsoft.AspNetCore.Mvc;
using Oefening_06_01_PersonsMVC.Entities;
using Oefening_06_01_PersonsMVC.Services;
using Oefening_06_01_PersonsMVC.ViewModels;

namespace Oefening_06_01_PersonsMVC.Controllers;
[Route("[controller]/[action]")]
public class HomeController : Controller
{
    private IPersonData personData;
    public HomeController(IPersonData personData)
    {
        this.personData = personData;
    }
    [HttpGet]
    public IActionResult Index()
    {
        var model = personData.GetAll();
        return Ok(model);
    }
    [HttpGet("{id}")]
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
    [HttpDelete("{id}")]
    public IActionResult Delete(long id)
    {
        personData.Delete(id);
        return NoContent();
    }
    [HttpPut("{id}")]
    public IActionResult Update([FromBody] PersonUpdateViewModel model)
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
        personData.Update(newPerson);
        return CreatedAtAction(nameof(Details), new { id = newPerson.Id }, newPerson);
    }
}