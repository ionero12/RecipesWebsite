using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesWebsite_BackendApi.Models;

[Table("categories_has_recipes")]
public class RecipeCategory
{
    public RecipeCategory()
    {
    }

    public RecipeCategory(int idRecipe, Recipe recipe, int idCategory, Category category)
    {
        IdRecipe = idRecipe;
        Recipe = recipe;
        IdCategory = idCategory;
        Category = category;
    }

    [Column("recipes_id_recipe")] public int IdRecipe { get; set; }
    public Recipe Recipe { get; set; }
    [Column("categories_id_category")] public int IdCategory { get; set; }
    public Category Category { get; set; }
}