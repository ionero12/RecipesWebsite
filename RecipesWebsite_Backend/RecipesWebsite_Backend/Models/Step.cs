using System.ComponentModel.DataAnnotations.Schema;

namespace RecipesWebsite_Backend.Models;

[Table("steps")]
public class Step
{
    public Recipe Recipe;

    [Column("id_step")] public int IdStep { get; set; }

    [Column("step_number")] public int StepNumber { get; set; }

    [Column("step_description")] public string StepDescription { get; set; }

    [Column("step_image")] public string StepImage { get; set; }

    [Column("recipes_id_recipe")] public int IdRecipe { get; set; }
}