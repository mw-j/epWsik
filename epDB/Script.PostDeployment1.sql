if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName, LastName)
	values ('Max', 'Mustermann'),('Tina','Bertel'),('Jan','Häcker'),('Doro','Weiler')
end