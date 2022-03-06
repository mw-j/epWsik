CREATE PROCEDURE [dbo].[sp_User_Update]
	@UserId uniqueidentifier,
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(255),
	@Password nvarchar(255)
AS
BEGIN
	UPDATE dbo.[User]
	SET 
		FirstName = @FirstName, 
		LastName = @LastName,
		EMail = @Email,
		[Password] = @Password
	WHERE UserId = @UserId
END
