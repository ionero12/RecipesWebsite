using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesWebsite_BackendApi.Models;

[Table("categories")]
public class Category
{
    public Category()
    {
    }

    public Category(int idCategory, string categoryName, List<RecipeCategory> recipeCategories)
    {
        IdCategory = idCategory;
        CategoryName = categoryName;
        RecipeCategories = recipeCategories;
    }

    [Column("id_category")] public int IdCategory { get; set; }

    [Column("category_name")] public string CategoryName { get; set; }

    public List<RecipeCategory> RecipeCategories { get; set; }
}