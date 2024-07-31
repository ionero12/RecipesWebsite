using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesWebsite_BackendApi.Models;

[Table("users_has_favorites")]
public class UserFavorite
{
    public UserFavorite()
    {
    }

    public UserFavorite(int idUser, User user, int idRecipe, Recipe recipe)
    {
        IdUser = idUser;
        User = user;
        IdRecipe = idRecipe;
        Recipe = recipe;
    }

    [Column("users_id_user")] public int IdUser { get; set; }
    public User User { get; set; }
    [Column("recipes_id_recipe")] public int IdRecipe { get; set; }
    public Recipe Recipe { get; set; }
}