CREATE PROCEDURE [dbo].[sp_User_Delete]
	@UserId uniqueidentifier
AS
BEGIN
	DELETE FROM dbo.[User]
	WHERE UserId = @UserId
END
