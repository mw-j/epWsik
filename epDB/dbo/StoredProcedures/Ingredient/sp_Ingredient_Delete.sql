CREATE PROCEDURE [dbo].[sp_Ingredient_Delete]
	@IngredientId uniqueidentifier
AS
BEGIN
	DELETE FROM dbo.Ingredient
	WHERE IngredientId = @IngredientId
END