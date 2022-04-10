CREATE PROCEDURE [dbo].[sp_Ingredient_GetByIngredientId.sql]
	@IngredientId uniqueidentifier
AS
BEGIN
	SELECT IngredientId, [Name], ShelfLife
	FROM dbo.Ingredient
	Where IngredientId = @IngredientId
END