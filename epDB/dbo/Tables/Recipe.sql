CREATE TABLE [dbo].[Recipe]
(
	[RecipeId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(), 
    [Title] NVARCHAR(150) NULL, 
    [WorkingTime] INT NULL, 
    [PreparationTime] INT NULL
)
