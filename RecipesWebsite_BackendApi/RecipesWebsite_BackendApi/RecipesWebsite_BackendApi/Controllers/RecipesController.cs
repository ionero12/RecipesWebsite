using Microsoft.AspNetCore.Mvc;
using RecipesWebsite_BackendApi.Models;
using RecipesWebsite_BackendApi.Services;

namespace RecipesWebsite_BackendApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RecipesController : ControllerBase
{
    private readonly IRecipeService _recipeService;

    public RecipesController(IRecipeService recipeService)
    {
        _recipeService = recipeService;
    }

    // GET: api/Recipes
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipes()
    {
        var recipes = await _recipeService.GetAllRecipesAsync();
        return Ok(recipes);
    }

    // GET: api/Recipes/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Recipe>> GetRecipe(int id)
    {
        var recipe = await _recipeService.GetRecipeByIdAsync(id);
        if (recipe == null) return NotFound();
        return Ok(recipe);
    }

    // GET: api/Recipes/RecipesByCategory/{categoryId}
    [HttpGet("RecipesByCategory/{categoryId}")]
    public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipesByCategory(int categoryId)
    {
        var recipes = await _recipeService.GetRecipesByCategoryAsync(categoryId);
        if (recipes == null || !recipes.Any()) return NotFound();
        return Ok(recipes);
    }

    // GET: api/Recipes/RecipesByUser/{userId}
    [HttpGet("RecipesByUser/{userId}")]
    public async Task<ActionResult<IEnumerable<Recipe>>> GetRecipesByUser(int userId)
    {
        var recipes = await _recipeService.GetRecipesByUserAsync(userId);
        if (recipes == null || !recipes.Any()) return NotFound();
        return Ok(recipes);
    }

    // GET: api/Recipes/RecipeByIngredients
    [HttpGet("RecipeByIngredients")]
    public async Task<ActionResult<IEnumerable<Recipe>>> SearchByIngredients(
        [FromQuery(Name = "ingredients")] string ingredients)
    {
        if (string.IsNullOrWhiteSpace(ingredients)) return BadRequest("The ingredients query parameter is required.");

        var ingredientList = ingredients.Split(',').Select(i => i.Trim().ToLower()).ToList();
        var recipes = await _recipeService.SearchRecipesByIngredientsAsync(ingredientList);

        return Ok(recipes);
    }
}