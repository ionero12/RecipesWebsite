namespace RecipesWebsite_BackendApi.Models;

public interface IUserRepository
{
    Task<User> GetUserByEmailAsync(string email);
    Task AddUserAsync(User user);
    Task SaveChangesAsync();

    Task<User> GetUserByIdAsync(int userId);
}