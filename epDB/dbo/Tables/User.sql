CREATE TABLE [dbo].[User]
(
	[UserId] uniqueidentifier NOT NULL PRIMARY KEY DEFAULT newid(), 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL
)
