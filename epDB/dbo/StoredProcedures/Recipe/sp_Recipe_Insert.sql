CREATE PROCEDURE [dbo].[sp_Recipe_Insert]
	@Title nvarchar(150),
	@WorkingTime int,
	@PreparationTime int,
	@RecipeId uniqueidentifier
AS
BEGIN
	DECLARE @Id uniqueidentifier = newid();
	INSERT INTO dbo.Recipe(RecipeId, Title, WorkingTime, PreparationTime)
	VALUES (@Id, @Title, @WorkingTime, @PreparationTime);
	SELECT @RecipeId = @Id
END