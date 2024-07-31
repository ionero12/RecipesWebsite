using Microsoft.AspNetCore.Mvc;
using RecipesWebsite_BackendApi.Models;
using RecipesWebsite_BackendApi.Services;

namespace RecipesWebsite_BackendApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class IngredientsController : ControllerBase
{
    private readonly IIngredientService _ingredientService;

    public IngredientsController(IIngredientService ingredientService)
    {
        _ingredientService = ingredientService;
    }

    // GET: api/Ingredients
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredients()
    {
        var ingredients = await _ingredientService.GetAllIngredientsAsync();
        return Ok(ingredients);
    }

    // GET: api/Ingredients/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Ingredient>> GetIngredient(int id)
    {
        var ingredient = await _ingredientService.GetIngredientByIdAsync(id);
        if (ingredient == null) return NotFound();
        return Ok(ingredient);
    }

    // GET: api/Ingredients/ByRecipe/{recipeId}
    [HttpGet("ByRecipe/{recipeId}")]
    public async Task<ActionResult<IEnumerable<Ingredient>>> GetIngredientsByRecipe(int recipeId)
    {
        var ingredients = await _ingredientService.GetIngredientsByRecipeAsync(recipeId);
        if (ingredients == null || !ingredients.Any()) return NotFound();
        return Ok(ingredients);
    }
}