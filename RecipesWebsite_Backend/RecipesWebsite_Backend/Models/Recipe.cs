using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace RecipesWebsite_Backend.Models;

[Table("recipes")]
public class Recipe
{
    [Column("id_recipe")] public int IdRecipe { get; set; }

    [Column("recipe_name")] public string RecipeName { get; set; }

    [Column("recipe_photo")] public string RecipePhoto { get; set; }

    [Column("recipe_prepare_time")] public string RecipePrepareTime { get; set; }

    [Column("recipe_cook_time")] public string RecipeCookTime { get; set; }

    [Column("recipe_portions_number")] public string RecipePortionsNumber { get; set; }

    [JsonIgnore] public List<Ingredient> Ingredients { get; set; }

    public List<Step> Steps { get; set; }
    public List<RecipeCategory> RecipeCategories { get; set; }
}