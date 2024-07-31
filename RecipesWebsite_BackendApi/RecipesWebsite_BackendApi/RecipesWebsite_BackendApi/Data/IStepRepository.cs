namespace RecipesWebsite_BackendApi.Models;

public interface IStepRepository
{
    Task<IEnumerable<Step>> GetAllStepsAsync();
    Task<Step> GetStepByIdAsync(int id);
    Task<IEnumerable<Step>> GetStepsByRecipeAsync(int recipeId);
}