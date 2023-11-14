using Microsoft.AspNetCore.Mvc;

using Voorbeeld_06_01_HelloCore.Entities;
using Voorbeeld_06_01_HelloCore.Services;
using Voorbeeld_06_01_HelloCore.ViewModels;

namespace Voorbeeld_06_01_HelloCore.Controllers;
[Route("[controller]/[action]")]
public class HomeController : Controller
{
    private readonly IRestaurantData restaurantData;
    private readonly IGreeter greeter;

    public HomeController(IRestaurantData restaurantData, IGreeter greeter)
    {
        this.restaurantData = restaurantData;
        this.greeter = greeter;
    }

    [HttpGet]
    public IActionResult Index()
    {
        //var restaurant = new Restaurant() { Id = 1, Name = "The Restaurant" };
        //var restaurants = restaurantData.GetAll();
        //return new ObjectResult(restaurants);
        var model = new HomePageViewModel();
        model.Restaurants = restaurantData.GetAll();
        model.CurrentMessage = greeter.GetGreeting();
        return new ObjectResult(model);
    }
    [HttpGet("{id}")]
    public IActionResult Detail(int id)
    {
        var restaurant = restaurantData.Get(id);
        if (restaurant is null)
        {
            return NotFound();
        }
        return Ok(restaurant);
    }
    [HttpPost()]
    public IActionResult Create([FromBody] RestaurantCreateViewModel restaurantCreateViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var newRestaurant = new Restaurant()
        {
            Name = restaurantCreateViewModel.Name,
            CuisineType = restaurantCreateViewModel.CuisineType,
        };
        restaurantData.Add(newRestaurant);
        return CreatedAtAction(nameof(Detail), new { newRestaurant.Id }, newRestaurant);
    }
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var restaurant = restaurantData.Get(id);
        if (restaurant is null)
        {
            return NotFound();
        }
        restaurantData.Delete(restaurant);
        return NoContent();
    }
    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] RestaurantUpdateViewModel restaurantUpdateViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        var restaurant = restaurantData.Get(id);
        if (restaurant is null)
        {
            return NotFound();
        }
        var updatedRestaurant = new Restaurant()
        {
            Id = restaurant.Id,
            Name = restaurantUpdateViewModel.Name,
            CuisineType = restaurantUpdateViewModel.CuisineType
        };
        restaurantData.Update(updatedRestaurant);
        return NoContent();
    }
}
