using RecipesWebsite_BackendApi.Models;

namespace RecipesWebsite_BackendApi.Services;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return _categoryRepository.GetAllCategoriesAsync();
    }

    public Task<Category> GetCategoryByIdAsync(int id)
    {
        return _categoryRepository.GetCategoryByIdAsync(id);
    }

    public Task<IEnumerable<Category>> GetCategoriesByRecipeAsync(int recipeId)
    {
        return _categoryRepository.GetCategoriesByRecipeAsync(recipeId);
    }
}