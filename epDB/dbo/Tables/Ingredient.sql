CREATE TABLE [dbo].[Ingredient]
(
	[IngredientId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(), 
    [Name] NVARCHAR(150),
	[ShelfLife] INT NULL
)
