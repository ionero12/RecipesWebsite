using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using RecipesWebsite_BackendApi.Services;

namespace RecipesWebsite_BackendApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ITokenService _tokenService;

    public UserController(IUserService userService, ITokenService tokenService)
    {
        _userService = userService;
        _tokenService = tokenService;
    }

    // POST: api/User/register
    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        try
        {
            var user = await _userService.RegisterUserAsync(request);
            return Ok(new { Message = "Registration successful." });
        }
        catch (ArgumentException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (InvalidOperationException ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
        catch (Exception ex)
        {
            // Log exception here
            return StatusCode(500, new { Message = "An error occurred while processing your request." });
        }
    }

    // POST: api/User/login
    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        try
        {
            var (user, token) = await _userService.LoginUserAsync(request);

            // Set the token in a secure cookie
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = false,
                SameSite = SameSiteMode.None,
                Expires = DateTime.UtcNow.AddHours(1)
            };

            Response.Cookies.Append("jwt", token, cookieOptions);

            return Ok(new { Message = "Login successful" , UserId=user.IdUser});
        }
        catch (InvalidOperationException)
        {
            return BadRequest(new { Message = "Invalid email or password." });
        }
        catch (ArgumentException)
        {
            return BadRequest(new { Message = "Invalid input." });
        }
    }
}