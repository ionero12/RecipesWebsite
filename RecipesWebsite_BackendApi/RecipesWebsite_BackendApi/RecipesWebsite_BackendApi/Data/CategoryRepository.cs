using Microsoft.EntityFrameworkCore;

namespace RecipesWebsite_BackendApi.Models;

public class CategoryRepository : ICategoryRepository
{
    private readonly ApplicationDbContext _context;

    public CategoryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
    {
        return await _context.Categories.ToListAsync();
    }

    public async Task<Category> GetCategoryByIdAsync(int id)
    {
        return await _context.Categories.FindAsync(id);
    }

    public async Task<IEnumerable<Category>> GetCategoriesByRecipeAsync(int recipeId)
    {
        return await _context.RecipeCategories
            .Where(rc => rc.IdRecipe == recipeId)
            .Select(rc => rc.Category)
            .ToListAsync();
    }
}