CREATE PROCEDURE [dbo].[sp_Recipe_GetRecipes]
AS
BEGIN
	SELECT
		Recipe.Title,
		Recipe.WorkingTime,
		Recipe.PreparationTime,
		Ingredient.Name,
		Ingredient.ShelfLife,
		Mapping_Recipe_Ingredient.Amount
	FROM Recipe 
	INNER JOIN Mapping_Recipe_Ingredient ON Recipe.RecipeId = Mapping_Recipe_Ingredient.RecipeId
	LEFT JOIN Ingredient ON Mapping_Recipe_Ingredient.IngredientId = Ingredient.IngredientId
END
