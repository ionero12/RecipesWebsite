using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesWebsite_Backend.Models;

[Table("categories_has_recipes")]
public class RecipeCategory
{
    [Column("recipes_id_recipe")] public int IdRecipe { get; set; }

    public Recipe Recipe { get; set; }

    [Column("categories_id_category")] public int IdCategory { get; set; }

    public Category Category { get; set; }
}