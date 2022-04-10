CREATE PROCEDURE [dbo].[sp_User_Insert]
	@FirstName nvarchar(50),
	@LastName nvarchar(50),
	@Email nvarchar(255),
	@Password nvarchar(255)
AS
BEGIN
	INSERT INTO dbo.[User] (FirstName, LastName, EMail, [Password])
	VALUES (@FirstName, @LastName, @Email, @Password)
END
