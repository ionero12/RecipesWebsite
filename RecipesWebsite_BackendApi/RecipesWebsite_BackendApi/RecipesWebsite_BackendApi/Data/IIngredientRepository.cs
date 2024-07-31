namespace RecipesWebsite_BackendApi.Models;

public interface IIngredientRepository
{
    Task<IEnumerable<Ingredient>> GetAllIngredientsAsync();
    Task<Ingredient> GetIngredientByIdAsync(int id);
    Task<IEnumerable<Ingredient>> GetIngredientsByRecipeAsync(int recipeId);
}