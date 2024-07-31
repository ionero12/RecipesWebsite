using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesWebsite_BackendApi.Models;

[Table("ingredients")]
public class Ingredient
{
    public Ingredient()
    {
    }

    public Ingredient(int idIngredient, string ingredientName, int ingredientQuantity, string ingredientUnit,
        int idRecipe)
    {
        IdIngredient = idIngredient;
        IngredientName = ingredientName;
        IngredientQuantity = ingredientQuantity;
        IngredientUnit = ingredientUnit;
        IdRecipe = idRecipe;
    }

    [Column("id_ingredient")] public int IdIngredient { get; set; }

    [Column("ingredient_name")] public string IngredientName { get; set; }

    [Column("ingredient_quantity")] public int IngredientQuantity { get; set; }

    [Column("ingredient_unit")] public string IngredientUnit { get; set; }

    [Column("recipes_id_recipe")] public int IdRecipe { get; set; }

    public Recipe Recipe { get; set; }
}