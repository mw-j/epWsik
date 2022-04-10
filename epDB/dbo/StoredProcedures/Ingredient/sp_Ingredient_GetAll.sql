CREATE PROCEDURE [dbo].[sp_Ingredient_GetAll]
AS
BEGIN
	SELECT IngredientId, [Name], ShelfLife
	FROM dbo.Ingredient
END