using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesWebsite_Backend.Models;

namespace RecipesWebsite_Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RecipesApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/RecipesApi
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
    {
        return await _context.Recipes.ToListAsync();
    }

    // GET: api/RecipesApi/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Recipe>> GetRecipe(int id)
    {
        var recipe = await _context.Recipes.FindAsync(id);

        if (recipe == null) return NotFound();

        return recipe;
    }

    // GET: api/RecipesApi/RecipesByCategory/{categoryId}
    [HttpGet("RecipesByCategory/{categoryId}")]
    public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipesByCategory(int categoryId)
    {
        var recipes = await _context.RecipeCategories
            .Where(rc => rc.IdCategory == categoryId)
            .Select(rc => rc.Recipe)
            .ToListAsync();

        if (recipes == null || recipes.Count == 0) return NotFound();

        return recipes;
    }

// GET: api/RecipesApi/RecipeByIngredients
    [HttpGet("RecipeByIngredients")]
    public async Task<ActionResult<IEnumerable<Recipe>>> SearchByIngredients([FromQuery(Name = "ingredients")] string ingredients)
    {
        if (string.IsNullOrWhiteSpace(ingredients))
        {
            return BadRequest("The ingredients query parameter is required.");
        }

        var ingredientList = ingredients.Split(',')
            .Select(i => i.Trim().ToLower())
            .ToList();

        var recipes = await _context.Recipes
            .Include(r => r.Ingredients)
            .ToListAsync();

        // Filtrăm rețetele care au cel puțin 70% din ingredientele cerute
        recipes = recipes.Where(r => {
                var recipeIngredients = r.Ingredients
                    .Select(ri => ri.IngredientName.ToLower())
                    .ToList();

                // Numărăm ingredientele din rețetă care sunt prezente și în lista trimisă
                int matchingIngredientsCount = recipeIngredients
                    .Intersect(ingredientList)
                    .Count();

                // Calculăm procentul de ingrediente din lista trimisă care sunt prezente în rețetă
                double matchingPercentage = (double)matchingIngredientsCount / ingredientList.Count * 100;

                // Verificăm dacă procentul de ingrediente potrivite este cel puțin 70%
                return matchingPercentage >= 70;
            })
            .ToList();

        return Ok(recipes);
    }
}