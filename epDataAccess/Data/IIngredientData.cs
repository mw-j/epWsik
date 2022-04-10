using epDataAccess.Models;

namespace epDataAccess.Data
{
    public interface IIngredientData
    {
        Task DeleteIngredient(Guid ingredientId);
        Task<IngredientModel?> GetIngredient(Guid ingredientId);
        Task<IEnumerable<IngredientModel>> GetIngredients();
        Task InsertIngredient(IngredientModel ingredient);
        Task UpdateIngredient(IngredientModel ingredient);
    }
}
