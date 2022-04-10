namespace epAPI.APIs
{
    internal static class IngredientAPI
    {
        internal static async Task<IResult> GetIngredients(IIngredientData data)
        {
            try
            {
                return Results.Ok(await data.GetIngredients());
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        internal static async Task<IResult> GetIngredient(Guid IngredientId, IIngredientData data)
        {
            try
            {
                var results = await data.GetIngredient(IngredientId);
                if (results == null) return Results.NotFound();
                return Results.Ok(results);
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        internal static async Task<IResult> InsertIngredient(IngredientModel Ingredient, IIngredientData data)
        {
            try
            {
                await data.InsertIngredient(Ingredient);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        internal static async Task<IResult> UpdateIngredient(IngredientModel Ingredient, IIngredientData data)
        {
            try
            {
                await data.UpdateIngredient(Ingredient);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }

        internal static async Task<IResult> DeleteIngredient(Guid IngredientId, IIngredientData data)
        {
            try
            {
                await data.DeleteIngredient(IngredientId);
                return Results.Ok();
            }
            catch (Exception ex)
            {

                return Results.Problem(ex.Message);
            }
        }
    }
}
