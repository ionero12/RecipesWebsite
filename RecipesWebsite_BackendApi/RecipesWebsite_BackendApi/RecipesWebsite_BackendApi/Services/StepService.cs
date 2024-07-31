using RecipesWebsite_BackendApi.Models;

namespace RecipesWebsite_BackendApi.Services;

public class StepService : IStepService
{
    private readonly IStepRepository _stepRepository;

    public StepService(IStepRepository stepRepository)
    {
        _stepRepository = stepRepository;
    }

    public Task<IEnumerable<Step>> GetAllStepsAsync()
    {
        return _stepRepository.GetAllStepsAsync();
    }

    public Task<Step> GetStepByIdAsync(int id)
    {
        return _stepRepository.GetStepByIdAsync(id);
    }

    public Task<IEnumerable<Step>> GetStepsByRecipeAsync(int recipeId)
    {
        return _stepRepository.GetStepsByRecipeAsync(recipeId);
    }
}