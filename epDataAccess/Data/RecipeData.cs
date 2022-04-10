using Dapper;
using epDataAccess.DbAccess;
using epDataAccess.Models;
using System.Data;
using System.Data.SqlClient;

namespace epDataAccess.Data
{
    public class RecipeData : IRecipeData
    {
        private readonly ISqlDataAccess _db;

        public RecipeData(ISqlDataAccess db)
        {
            _db = db;
        }

        public Task DeleteRecipe(Guid RecipeId)
        {
            throw new NotImplementedException();
        }

        public Task<RecipeModel?> GetRecipe(Guid RecipeId)
        {
            throw new NotImplementedException();
        }

        public Task<RecipeModel?> GetRecipeByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<RecipeModel>> GetRecipes()
        {
            var sql = @"SELECT
                            Recipe.RecipeId,
	                        Recipe.Title,
	                        Recipe.WorkingTime,
	                        Recipe.PreparationTime,
                            Ingredient.IngredientId,
	                        Ingredient.Name,
	                        Ingredient.ShelfLife,
	                        Mapping_Recipe_Ingredient.Amount
                        FROM Recipe 
                        INNER JOIN Mapping_Recipe_Ingredient ON Recipe.RecipeId = Mapping_Recipe_Ingredient.RecipeId
                        LEFT JOIN Ingredient ON Mapping_Recipe_Ingredient.IngredientId = Ingredient.IngredientId";

            var results = await _db.LoadDataMultiMap<RecipeModel, IngredientAmountModel, dynamic>(sql, parentKeySelector, childSelector, new { }, "IngredientId");
            return results;
        }
        public Task InsertRecipe(RecipeModel Recipe)
        {
            throw new NotImplementedException();
        }

        public Task UpdateRecipe(RecipeModel Recipe)
        {
            throw new NotImplementedException();
        }

        private Guid parentKeySelector(RecipeModel recipe) {
            return recipe.RecipeId;
        }
        private List<IngredientAmountModel> childSelector(RecipeModel recipe)
        {
            return recipe.Ingredients;
        }
    }
}
