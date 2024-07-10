using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesWebsite_Backend.Models;

namespace RecipesWebsite_Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientsApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public IngredientsApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/IngredientsApi
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients()
    {
        return await _context.Ingredients.ToListAsync();
    }

    // GET: api/IngredientsApi/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Ingredient>> GetIngredient(int id)
    {
        var ingredient = await _context.Ingredients.FindAsync(id);

        if (ingredient == null) return NotFound();

        return ingredient;
    }

    // GET: api/IngredientsApi/ByRecipe/5
    [HttpGet("ByRecipe/{recipeId}")]
    public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredientsByRecipe(int recipeId)
    {
        var ingredients = await _context.Ingredients
            .Where(i => i.IdRecipe == recipeId)
            .ToListAsync();

        if (ingredients == null || ingredients.Count == 0) return NotFound();

        return ingredients;
    }
}