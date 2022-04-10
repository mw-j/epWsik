CREATE PROCEDURE [dbo].[sp_Ingredient_Insert]
	@Name nvarchar(150),
	@ShelfLife int,
	@IngredientId uniqueidentifier
AS
BEGIN
	DECLARE @Id uniqueidentifier = newid();
	INSERT INTO dbo.Ingredient (IngredientId, [Name], ShelfLife)
	VALUES (@Id, @Name, @ShelfLife);
	SELECT @IngredientId = @Id
END
