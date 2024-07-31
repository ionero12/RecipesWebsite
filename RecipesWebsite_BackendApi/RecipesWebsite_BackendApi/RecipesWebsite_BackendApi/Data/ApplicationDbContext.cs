using Microsoft.EntityFrameworkCore;

namespace RecipesWebsite_BackendApi.Models;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<Step> Steps { get; set; }
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<User> Users { get; set; }
    public DbSet<RecipeCategory> RecipeCategories { get; set; }
    public DbSet<UserFavorite> UserFavorites { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurare cheie primară pentru Category
        modelBuilder.Entity<Category>()
            .HasKey(c => c.IdCategory);

        // Configurare cheie primară pentru Ingredient
        modelBuilder.Entity<Ingredient>()
            .HasKey(i => i.IdIngredient);

        // Configurare cheie primară pentru Recipe
        modelBuilder.Entity<Recipe>()
            .HasKey(r => r.IdRecipe);

        // Configurare cheie primară pentru Step
        modelBuilder.Entity<Step>()
            .HasKey(s => s.IdStep);
        
        // Configurare cheie primară pentru User
        modelBuilder.Entity<User>()
            .HasKey(s => s.IdUser);

        // Configurare relații one-to-many
        modelBuilder.Entity<Ingredient>()
            .HasOne(i => i.Recipe)
            .WithMany(r => r.Ingredients)
            .HasForeignKey(i => i.IdRecipe);

        modelBuilder.Entity<Step>()
            .HasOne(s => s.Recipe)
            .WithMany(r => r.Steps)
            .HasForeignKey(s => s.IdRecipe);

        // Configurare relație many-to-many
        modelBuilder.Entity<RecipeCategory>()
            .HasKey(rc => new { rc.IdRecipe, rc.IdCategory });

        modelBuilder.Entity<RecipeCategory>()
            .HasOne(rc => rc.Recipe)
            .WithMany(r => r.RecipeCategories)
            .HasForeignKey(rc => rc.IdRecipe);

        modelBuilder.Entity<RecipeCategory>()
            .HasOne(rc => rc.Category)
            .WithMany(c => c.RecipeCategories)
            .HasForeignKey(rc => rc.IdCategory);

        modelBuilder.Entity<UserFavorite>()
            .HasKey(rc => new { rc.IdRecipe, rc.IdUser });

        modelBuilder.Entity<UserFavorite>()
            .HasOne(rc => rc.Recipe)
            .WithMany(r => r.UserFavorites)
            .HasForeignKey(rc => rc.IdRecipe);

        modelBuilder.Entity<UserFavorite>()
            .HasOne(rc => rc.User)
            .WithMany(c => c.UserFavorites)
            .HasForeignKey(rc => rc.IdUser);

        base.OnModelCreating(modelBuilder);
    }
}