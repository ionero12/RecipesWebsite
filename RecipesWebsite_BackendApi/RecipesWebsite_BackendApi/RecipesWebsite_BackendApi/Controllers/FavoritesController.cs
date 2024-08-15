using Microsoft.AspNetCore.Mvc;
using RecipesWebsite_BackendApi.Services;

namespace RecipesWebsite_BackendApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FavoritesController : ControllerBase
{
    private readonly IUserService _userService;

    public FavoritesController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost("toggle")]
    public async Task<IActionResult> ToggleFavorite([FromBody] ToggleFavoriteRequest request)
    {
        if (request == null || request.UserId <= 0 || request.RecipeId <= 0)
        {
            return BadRequest("Invalid input.");
        }

        try
        {
            await _userService.ToggleFavoriteAsync(request.UserId, request.RecipeId);
            return Ok();
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { Message = "An internal server error occurred.", Error = ex.Message });
        }
    }
}

public class ToggleFavoriteRequest
{
    public int UserId { get; set; }
    public int RecipeId { get; set; }
}
