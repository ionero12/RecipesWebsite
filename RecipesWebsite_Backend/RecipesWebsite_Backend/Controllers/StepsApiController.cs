using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecipesWebsite_Backend.Models;

namespace RecipesWebsite_Backend.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StepsApiController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public StepsApiController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: api/StepsApi
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Step>>> GetSteps()
    {
        return await _context.Steps.ToListAsync();
    }

    // GET: api/StepsApi/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Step>> GetStep(int id)
    {
        var step = await _context.Steps.FindAsync(id);

        if (step == null) return NotFound();

        return step;
    }

    // GET: api/StepsApi/ByRecipe/5
    [HttpGet("ByRecipe/{recipeId}")]
    public async Task<ActionResult<IEnumerable<Step>>> getStepsByRecipe(int recipeId)
    {
        var steps = await _context.Steps
            .Where(i => i.IdRecipe == recipeId)
            .ToListAsync();

        if (steps == null || steps.Count == 0) return NotFound();

        return steps;
    }
}