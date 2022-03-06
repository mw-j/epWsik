CREATE PROCEDURE [dbo].[sp_User_Update]
	@UserId uniqueidentifier,
	@FirstName nvarchar(50),
	@LastName nvarchar(50)
AS
BEGIN
	UPDATE dbo.[User]
	SET FirstName = @FirstName, LastName = @LastName
	WHERE UserId = @UserId
END
