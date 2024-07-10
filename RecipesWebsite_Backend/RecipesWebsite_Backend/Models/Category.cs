using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesWebsite_Backend.Models;

[Table("categories")]
public class Category
{
    [Column("id_category")] public int IdCategory { get; set; }

    [Column("category_name")] public string CategoryName { get; set; }

    public List<RecipeCategory> RecipeCategories { get; set; }
}