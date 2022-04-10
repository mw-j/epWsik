using epDataAccess.Models;

namespace epDataAccess.Data
{
    public interface IRecipeData
    {
        Task DeleteRecipe(Guid RecipeId);
        Task<RecipeModel?> GetRecipe(Guid RecipeId);
        Task<RecipeModel?> GetRecipeByEmail(string email);
        Task<IEnumerable<RecipeModel>> GetRecipes();
        Task InsertRecipe(RecipeModel Recipe);
        Task UpdateRecipe(RecipeModel Recipe);
    }
}
