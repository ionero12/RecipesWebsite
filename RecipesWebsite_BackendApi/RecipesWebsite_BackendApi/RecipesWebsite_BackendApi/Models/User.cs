using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesWebsite_BackendApi.Models;

[Table("users")]
public class User
{
    public User()
    {
        UserFavorites = new List<UserFavorite>(); 
    }

    public User(int idUser, string email, string password, List<UserFavorite> userFavorites)
    {
        IdUser = idUser;
        Email = email;
        Password = password;
        UserFavorites = userFavorites ?? new List<UserFavorite>(); 
    }

    [Column("id_user")] public int IdUser { get; set; }
    [Column("email")] public string Email { get; set; }
    [Column("password")] public string Password { get; set; }

    public List<UserFavorite> UserFavorites { get; set; }
}