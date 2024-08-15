using Microsoft.AspNetCore.Identity.Data;
using RecipesWebsite_BackendApi.Models;

namespace RecipesWebsite_BackendApi.Services;

public interface IUserService
{
    Task<User> RegisterUserAsync(RegisterRequest request);
    Task<(User User, string Token)> LoginUserAsync(LoginRequest request);

    Task ToggleFavoriteAsync(int userId, int recipeId);
}