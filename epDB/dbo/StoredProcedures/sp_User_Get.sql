CREATE PROCEDURE [dbo].[sp_User_Get]
	@userId uniqueidentifier
AS
BEGIN
	SELECT UserId, FirstName, LastName
	FROM dbo.[User]
	WHERE UserId = @userId
END