using Microsoft.AspNetCore.Mvc;
using RecipesWebsite_BackendApi.Models;
using RecipesWebsite_BackendApi.Services;

namespace RecipesWebsite_BackendApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoriesController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    // GET: api/Categories
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }

    // GET: api/Categories/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Category>> GetCategory(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null) return NotFound();
        return Ok(category);
    }

    // GET: api/Categories/ByRecipe/{recipeId}
    [HttpGet("ByRecipe/{recipeId}")]
    public async Task<ActionResult<IEnumerable<Category>>> GetCategoriesByRecipe(int recipeId)
    {
        var categories = await _categoryService.GetCategoriesByRecipeAsync(recipeId);
        if (categories == null || !categories.Any()) return NotFound();
        return Ok(categories);
    }
}