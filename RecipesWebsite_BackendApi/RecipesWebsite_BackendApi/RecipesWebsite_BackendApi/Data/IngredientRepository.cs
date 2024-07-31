using Microsoft.EntityFrameworkCore;

namespace RecipesWebsite_BackendApi.Models;

public class IngredientRepository : IIngredientRepository
{
    private readonly ApplicationDbContext _context;

    public IngredientRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Ingredient>> GetAllIngredientsAsync()
    {
        return await _context.Ingredients.ToListAsync();
    }

    public async Task<Ingredient> GetIngredientByIdAsync(int id)
    {
        return await _context.Ingredients.FindAsync(id);
    }

    public async Task<IEnumerable<Ingredient>> GetIngredientsByRecipeAsync(int recipeId)
    {
        return await _context.Ingredients
            .Where(i => i.IdRecipe == recipeId)
            .ToListAsync();
    }
}