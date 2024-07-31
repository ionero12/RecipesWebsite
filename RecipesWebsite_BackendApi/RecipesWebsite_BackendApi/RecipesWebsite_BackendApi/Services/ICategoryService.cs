using RecipesWebsite_BackendApi.Models;

namespace RecipesWebsite_BackendApi.Services;

public interface ICategoryService
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);
    Task<IEnumerable<Category>> GetCategoriesByRecipeAsync(int recipeId);
}