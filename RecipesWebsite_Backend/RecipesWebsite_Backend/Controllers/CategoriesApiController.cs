using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesWebsite_Backend.Models;

namespace RecipesWebsite_Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public CategoriesApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/CategoriesApi
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        return await _context.Categories.ToListAsync();
    }

    // GET: api/CategoriesApi/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        var category = await _context.Categories.FindAsync(id);

        if (category == null) return NotFound();

        return category;
    }

    // GET: api/CategoriesApi/ByRecipe/{recipeId}
    [HttpGet("ByRecipe/{recipeId}")]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesByRecipe(int recipeId)
    {
        var categories = await _context.RecipeCategories
            .Where(rc => rc.IdRecipe == recipeId)
            .Select(rc => rc.Category)
            .ToListAsync();

        if (categories == null || categories.Count == 0) return NotFound();

        return categories;
    }
}