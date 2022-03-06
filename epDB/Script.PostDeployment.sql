if not exists (select 1 from dbo.[User])
begin
	insert into dbo.[User] (FirstName, LastName, EMail, Password)
	values ('Max', 'Mustermann', 'max.musterman@ep.local', '123'),
	('Tina','Bertel', 'tina.bertel@ep.local', '123'),
	('Jan','Häcker', 'jan.haeker@ep.local', '123'),
	('Doro','Weiler', 'doro.weiler@ep.local', '123')
end