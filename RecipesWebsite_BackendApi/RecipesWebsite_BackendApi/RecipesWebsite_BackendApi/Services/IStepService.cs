using RecipesWebsite_BackendApi.Models;

namespace RecipesWebsite_BackendApi.Services;

public interface IStepService
{
    Task<IEnumerable<Step>> GetAllStepsAsync();
    Task<Step> GetStepByIdAsync(int id);
    Task<IEnumerable<Step>> GetStepsByRecipeAsync(int recipeId);
}