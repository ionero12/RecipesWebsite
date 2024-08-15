using RecipesWebsite_BackendApi.Models;

namespace RecipesWebsite_BackendApi.Services;

public interface ITokenService
{
    string GenerateToken(User user);
}