CREATE TABLE [dbo].[Ingredient_Translation]
(
	[IngredientNonTransId] UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Ingredient(IngredientId) NOT NULL , 
    [LanguageId] CHAR(2) FOREIGN KEY REFERENCES Language(LanguageId) NOT NULL, 
    [Name] NVARCHAR(50) NULL, 
    [Description] NVARCHAR(4000) NULL, 
)
