using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity.Data;
using RecipesWebsite_BackendApi.Models;

namespace RecipesWebsite_BackendApi.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly ITokenService _tokenService;

    public UserService(IUserRepository userRepository, ITokenService tokenService)
    {
        _userRepository = userRepository;
        _tokenService = tokenService;
    }

    public async Task<User> RegisterUserAsync(RegisterRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email) || string.IsNullOrWhiteSpace(request.Password))
        {
            throw new ArgumentException("Email and password are required.");
        }
        
        var existingUser = await _userRepository.GetUserByEmailAsync(request.Email);
        if (existingUser != null)
        {
            throw new InvalidOperationException("User already exists.");
        }
        
        var hashedPassword = HashPassword(request.Password);
        
        var user = new User
        {
            Email = request.Email,
            Password = hashedPassword
        };
        
        await _userRepository.AddUserAsync(user);
        await _userRepository.SaveChangesAsync();

        return user;
    }

    public async Task<(User User, string Token)> LoginUserAsync(LoginRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Email?.Trim()) || string.IsNullOrWhiteSpace(request.Password?.Trim()))
        {
            throw new ArgumentException("Email and password are required.");
        }

        var user = await _userRepository.GetUserByEmailAsync(request.Email);
        if (user == null || !VerifyPassword(request.Password, user.Password))
        {
            throw new InvalidOperationException("Invalid email or password.");
        }

        var token = _tokenService.GenerateToken(user);

        return (user, token);
    }
    
    public string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password);
    }
    
    public bool VerifyPassword(string plainPassword, string hashedPassword)
    {
        return BCrypt.Net.BCrypt.Verify(plainPassword, hashedPassword);
    }
    
    public async Task ToggleFavoriteAsync(int userId, int recipeId)
    {
        var user = await _userRepository.GetUserByIdAsync(userId);

        if (user == null)
        {
            throw new ArgumentException("User not found.");
        }

        if (user.UserFavorites == null)
        {
            user.UserFavorites = new List<UserFavorite>();
        }

        var existingFavorite = user.UserFavorites
            .FirstOrDefault(f => f.IdRecipe == recipeId);

        if (existingFavorite != null)
        {
            user.UserFavorites.Remove(existingFavorite);
        }
        else
        {
            var newFavorite = new UserFavorite
            {
                IdUser = userId,
                IdRecipe = recipeId
            };
            user.UserFavorites.Add(newFavorite);
        }

        await _userRepository.SaveChangesAsync();
    }

}