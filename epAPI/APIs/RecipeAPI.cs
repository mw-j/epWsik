namespace epAPI.APIs
{
    internal static class RecipeAPI
    {
        internal static async Task<IResult> GetRecipes(IRecipeData data)
        {
            try
            {
                return Results.Ok(await data.GetRecipes());
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        internal static async Task<IResult> GetRecipe(Guid RecipeId, IRecipeData data)
        {
            try
            {
                var results = await data.GetRecipe(RecipeId);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        internal static async Task<IResult> InsertRecipe(RecipeModel Recipe, IRecipeData data)
        {
            try
            {
                await data.InsertRecipe(Recipe);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        internal static async Task<IResult> UpdateRecipe(RecipeModel Recipe, IRecipeData data)
        {
            try
            {
                await data.UpdateRecipe(Recipe);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        internal static async Task<IResult> DeleteRecipe(Guid RecipeId, IRecipeData data)
        {
            try
            {
                await data.DeleteRecipe(RecipeId);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
    }
}
