using RecipesWebsite_BackendApi.Models;

namespace RecipesWebsite_BackendApi.Services;

public class RecipeService : IRecipeService
{
    private readonly IRecipeRepository _recipeRepository;

    public RecipeService(IRecipeRepository recipeRepository)
    {
        _recipeRepository = recipeRepository;
    }

    public Task<IEnumerable<Recipe>> GetAllRecipesAsync()
    {
        return _recipeRepository.GetAllRecipesAsync();
    }

    public Task<Recipe> GetRecipeByIdAsync(int id)
    {
        return _recipeRepository.GetRecipeByIdAsync(id);
    }

    public Task<IEnumerable<Recipe>> GetRecipesByCategoryAsync(int categoryId)
    {
        return _recipeRepository.GetRecipesByCategoryAsync(categoryId);
    }

    public Task<IEnumerable<Recipe>> GetRecipesByUserAsync(int userId)
    {
        return _recipeRepository.GetRecipesByUserAsync(userId);
    }

    public Task<IEnumerable<Recipe>> SearchRecipesByIngredientsAsync(List<string> ingredients)
    {
        return _recipeRepository.SearchRecipesByIngredientsAsync(ingredients);
    }
}