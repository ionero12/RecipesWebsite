using RecipesWebsite_BackendApi.Models;

namespace RecipesWebsite_BackendApi.Services;

public interface IIngredientService
{
    Task<IEnumerable<Ingredient>> GetAllIngredientsAsync();
    Task<Ingredient> GetIngredientByIdAsync(int id);
    Task<IEnumerable<Ingredient>> GetIngredientsByRecipeAsync(int recipeId);
}