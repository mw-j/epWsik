CREATE TABLE [dbo].[Mapping_Recipe_Ingredient]
(
	[RecipeId] UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Recipe(RecipeId) NOT NULL ,
	[IngredientId] UNIQUEIDENTIFIER FOREIGN KEY REFERENCES Ingredient(IngredientId) NOT NULL ,
	[Amount] INT NOT NULL 
	
)
