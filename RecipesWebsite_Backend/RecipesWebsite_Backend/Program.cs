using Microsoft.EntityFrameworkCore;
using RecipesWebsite_Backend.Models;

var policyName = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(policyName,
        builder =>
        {
            builder
                .WithOrigins("http://localhost:3000") // specifying the allowed origin
                .WithMethods("GET") // defining the allowed HTTP method
                .AllowAnyHeader() // allowing any header to be sent
                .AllowCredentials(); // Ensure credentials are allowed if needed
        });
});

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext and configure MySQL connection
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("DefaultConnection"),
        new MySqlServerVersion(new Version(8, 0, 21))));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Enable CORS middleware
app.UseCors(policyName);

app.UseAuthorization();

app.MapControllers(); // Add mapping for API controllers

app.MapControllerRoute(
    "default",
    "{controller=Home}/{action=Index}/{id?}");

app.Run();