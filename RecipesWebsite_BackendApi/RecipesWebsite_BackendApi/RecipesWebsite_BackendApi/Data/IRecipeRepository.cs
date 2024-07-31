namespace RecipesWebsite_BackendApi.Models;

public interface IRecipeRepository
{
    Task<IEnumerable<Recipe>> GetAllRecipesAsync();
    Task<Recipe> GetRecipeByIdAsync(int id);
    Task<IEnumerable<Recipe>> GetRecipesByCategoryAsync(int categoryId);
    Task<IEnumerable<Recipe>> GetRecipesByUserAsync(int userId);
    Task<IEnumerable<Recipe>> SearchRecipesByIngredientsAsync(List<string> ingredients);
}