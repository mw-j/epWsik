if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName, LastName, EMail, Password)
	values ('Max', 'Mustermann', 'max.musterman@ep.local', '123'),
	('Tina','Bertel', 'tina.bertel@ep.local', '123'),
	('Jan','Häcker', 'jan.haeker@ep.local', '123'),
	('Doro','Weiler', 'doro.weiler@ep.local', '123')
end

if not exists (select 1 from dbo.Recipe)
begin
	insert into dbo.Recipe (Title, WorkingTime, PreparationTime)
	values 
	('Spaghetti',7,20),
	('Linsen mit Saiten und Spätzle',30,90),
	('Metaxa-Gryos mit Reis',15,60)
end

if not exists (select 1 from dbo.Ingredient)
begin
	insert into dbo.Ingredient ([Name], ShelfLife)
	values 
	('Spaghetti', 600),
	('Wiener', 2),
	('passierte Tomaten', 600),
	('Salz', 1)
end

if not exists (select 1 from dbo.Mapping_Recipe_Ingredient)
begin
	insert into dbo.Mapping_Recipe_Ingredient (RecipeId, IngredientId, Amount)
	values 
	('6dde7987-d365-4b1e-9b28-22bf004c0bed', 'bf1696f6-2a2f-40d5-b57e-10761f0f0188', 250), -- Spghetthi
	('6dde7987-d365-4b1e-9b28-22bf004c0bed', 'e6027ffb-b0eb-43a2-bb29-920ced850de7', 500), -- passierte Tomaten
	('6dde7987-d365-4b1e-9b28-22bf004c0bed', 'bb4939ed-548d-4081-b6d4-34531ad9e3c7', 10), -- Salz
	-- Linsen
	('e29f859d-9f84-4b46-b88e-82470e6f6a15','bb4939ed-548d-4081-b6d4-34531ad9e3c7', 10) -- Salz
end