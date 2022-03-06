CREATE PROCEDURE [dbo].[sp_User_GetByEmail]
	@email nvarchar(255)
AS
BEGIN
	SELECT UserId, FirstName, LastName, EMail, [Password]
	FROM dbo.[User]
	WHERE EMail = @email
END