CREATE PROCEDURE [dbo].[sp_User_GetAll]
AS
BEGIN
	SELECT UserId, FirstName, LastName
	FROM dbo.[User]
END