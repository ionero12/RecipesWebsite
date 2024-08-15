using Microsoft.EntityFrameworkCore;
using RecipesWebsite_BackendApi.Models;
using RecipesWebsite_BackendApi.Services;

var policyName = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(policyName,
        builder =>
        {
            builder
                .WithOrigins("http://localhost:3000") // specifying the allowed origin // dc nu merge cu adresa ip
                .AllowAnyMethod()  // defining the allowed HTTP method
                .AllowAnyHeader() // allowing any header to be sent
                .AllowCredentials(); // Ensure credentials are allowed if needed
        });
});

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext and configure MySQL connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(6, 0, 0))));

// Register services and repositories
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<IIngredientService, IngredientService>();
builder.Services.AddScoped<IIngredientRepository, IngredientRepository>();
builder.Services.AddScoped<IStepService, StepService>();
builder.Services.AddScoped<IStepRepository, StepRepository>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

// Enable CORS middleware
app.UseCors(policyName);

app.UseAuthorization();

app.MapControllers(); // Add mapping for API controllers

app.Run();