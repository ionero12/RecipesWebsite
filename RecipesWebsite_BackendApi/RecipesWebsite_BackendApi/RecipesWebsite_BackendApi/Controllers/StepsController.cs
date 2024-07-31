using Microsoft.AspNetCore.Mvc;
using RecipesWebsite_BackendApi.Models;
using RecipesWebsite_BackendApi.Services;

namespace RecipesWebsite_BackendApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StepsController : ControllerBase
{
    private readonly IStepService _stepService;

    public StepsController(IStepService stepService)
    {
        _stepService = stepService;
    }

    // GET: api/Steps
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Step>>> GetSteps()
    {
        var steps = await _stepService.GetAllStepsAsync();
        return Ok(steps);
    }

    // GET: api/Steps/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Step>> GetStep(int id)
    {
        var step = await _stepService.GetStepByIdAsync(id);
        if (step == null) return NotFound();
        return Ok(step);
    }

    // GET: api/Steps/ByRecipe/{recipeId}
    [HttpGet("ByRecipe/{recipeId}")]
    public async Task<ActionResult<IEnumerable<Step>>> GetStepsByRecipe(int recipeId)
    {
        var steps = await _stepService.GetStepsByRecipeAsync(recipeId);
        if (steps == null || !steps.Any()) return NotFound();
        return Ok(steps);
    }
}