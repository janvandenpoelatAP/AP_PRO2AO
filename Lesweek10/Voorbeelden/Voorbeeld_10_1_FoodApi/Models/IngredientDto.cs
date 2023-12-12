namespace Voorbeeld_10_01_FoodApi.Models;
public class IngredientDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid DishId { get; set; }
}