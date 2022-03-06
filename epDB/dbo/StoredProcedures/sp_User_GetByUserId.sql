CREATE PROCEDURE [dbo].[sp_User_GetByUserId]
	@userId uniqueidentifier
AS
BEGIN
	SELECT UserId, FirstName, LastName, EMail, [Password]
	FROM dbo.[User]
	WHERE UserId = @userId
END