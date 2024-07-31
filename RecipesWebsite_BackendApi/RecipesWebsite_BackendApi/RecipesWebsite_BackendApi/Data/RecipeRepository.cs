using Microsoft.EntityFrameworkCore;

namespace RecipesWebsite_BackendApi.Models;

public class RecipeRepository : IRecipeRepository
{
    private readonly ApplicationDbContext _context;

    public RecipeRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Recipe>> GetAllRecipesAsync()
    {
        return await _context.Recipes.ToListAsync();
    }

    public async Task<Recipe> GetRecipeByIdAsync(int id)
    {
        return await _context.Recipes.FindAsync(id);
    }

    public async Task<IEnumerable<Recipe>> GetRecipesByCategoryAsync(int categoryId)
    {
        return await _context.RecipeCategories
            .Where(rc => rc.IdCategory == categoryId)
            .Select(rc => rc.Recipe)
            .ToListAsync();
    }

    public async Task<IEnumerable<Recipe>> GetRecipesByUserAsync(int userId)
    {
        return await _context.UserFavorites
            .Where(uf => uf.IdUser == userId)
            .Select(uf => uf.Recipe)
            .ToListAsync();
    }

    public async Task<IEnumerable<Recipe>> SearchRecipesByIngredientsAsync(List<string> ingredients)
    {
        var recipes = await _context.Recipes
            .Include(r => r.Ingredients)
            .ToListAsync();

        recipes = recipes.Where(r =>
        {
            var recipeIngredients = r.Ingredients
                .Select(ri => ri.IngredientName.ToLower())
                .ToList();

            var matchingIngredientsCount = recipeIngredients
                .Intersect(ingredients)
                .Count();

            var matchingPercentage = (double)matchingIngredientsCount / ingredients.Count * 100;

            return matchingPercentage >= 70;
        }).ToList();

        return recipes;
    }
}