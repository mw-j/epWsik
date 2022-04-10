CREATE PROCEDURE [dbo].[sp_Ingredient_Update]
	@IngredientId uniqueidentifier,
	@Name nvarchar(150),
	@ShelfLife int
AS
BEGIN
	UPDATE dbo.Ingredient
	SET 
		[Name] = @Name,
		ShelfLife = @ShelfLife
	WHERE IngredientId = @IngredientId
END