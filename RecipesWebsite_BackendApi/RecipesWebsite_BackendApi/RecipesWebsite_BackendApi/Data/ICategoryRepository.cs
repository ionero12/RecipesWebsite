namespace RecipesWebsite_BackendApi.Models;

public interface ICategoryRepository
{
    Task<IEnumerable<Category>> GetAllCategoriesAsync();
    Task<Category> GetCategoryByIdAsync(int id);
    Task<IEnumerable<Category>> GetCategoriesByRecipeAsync(int recipeId);
}