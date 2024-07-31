using Microsoft.EntityFrameworkCore;

namespace RecipesWebsite_BackendApi.Models;

public class StepRepository : IStepRepository
{
    private readonly ApplicationDbContext _context;

    public StepRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Step>> GetAllStepsAsync()
    {
        return await _context.Steps.ToListAsync();
    }

    public async Task<Step> GetStepByIdAsync(int id)
    {
        return await _context.Steps.FindAsync(id);
    }

    public async Task<IEnumerable<Step>> GetStepsByRecipeAsync(int recipeId)
    {
        return await _context.Steps
            .Where(i => i.IdRecipe == recipeId)
            .ToListAsync();
    }
}