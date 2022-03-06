CREATE TABLE [dbo].[User]
(
	[UserId] uniqueidentifier NOT NULL PRIMARY KEY DEFAULT newid(), 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [EMail] NVARCHAR(255) NOT NULL UNIQUE, 
    [Password] NVARCHAR(255) NOT NULL
)
