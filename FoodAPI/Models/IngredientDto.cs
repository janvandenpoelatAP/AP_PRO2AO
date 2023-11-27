namespace Voorbeeld_09_1_FoodApi.Models;
public class IngredientDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public Guid DishId { get; set; }
}