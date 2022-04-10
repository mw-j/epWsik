CREATE PROCEDURE [dbo].[sp_map_Recipe_Ingredient_Insert]
	@RecipeId uniqueidentifier,
	@IngredientId uniqueidentifier,
	@Amount int
AS
BEGIN
	INSERT INTO dbo.Mapping_Recipe_Ingredient(RecipeId, IngredientId, Amount)
	VALUES (@RecipeId, @IngredientId, @Amount)
END