using RecipesWebsite_BackendApi.Models;

namespace RecipesWebsite_BackendApi.Services;

public class IngredientService : IIngredientService
{
    private readonly IIngredientRepository _ingredientRepository;

    public IngredientService(IIngredientRepository ingredientRepository)
    {
        _ingredientRepository = ingredientRepository;
    }

    public Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
    {
        return _ingredientRepository.GetAllIngredientsAsync();
    }

    public Task<Ingredient> GetIngredientByIdAsync(int id)
    {
        return _ingredientRepository.GetIngredientByIdAsync(id);
    }

    public Task<IEnumerable<Ingredient>> GetIngredientsByRecipeAsync(int recipeId)
    {
        return _ingredientRepository.GetIngredientsByRecipeAsync(recipeId);
    }
}