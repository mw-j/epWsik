using epDataAccess.DbAccess;
using epDataAccess.Models;

namespace epDataAccess.Data
{
    public class IngredientData : IIngredientData
    {
        private readonly ISqlDataAccess _db;

        public IngredientData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task DeleteIngredient(Guid ingredientId) =>
            _db.SaveData("dbo.sp_Ingredient_Delete", new { ingredientId });

        public async Task<IngredientModel?> GetIngredient(Guid ingredientId)
        {
            var results = await _db.LoadData<IngredientModel, dynamic>(
                "dbo.sp_Ingredient_GetByIngredientId",
                new { ingredientId });

            return results.FirstOrDefault();
        }

        public Task<IEnumerable<IngredientModel>> GetIngredients() =>
            _db.LoadData<IngredientModel, dynamic>("dbo.sp_Ingredient_GetAll", new { });

        public Task InsertIngredient(IngredientModel ingredient) =>
            _db.SaveData("dbo.sp_Ingredient_Insert", ingredient);

        public Task UpdateIngredient(IngredientModel ingredient) =>
            _db.SaveData("dbo.sp_Ingredient_Update", ingredient);
    }
}
