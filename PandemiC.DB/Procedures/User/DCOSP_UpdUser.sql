CREATE PROCEDURE [PandUser].[DCOSP_UpdUser]
	@Id           INT,
	@Email        NVARCHAR(20),
	@NatRegNbr    NVARCHAR(50),
	@LastName     NVARCHAR(50),
	@FirstName    NVARCHAR(50),
	@UserStatus   INT
AS
BEGIN
	UPDATE [dbo].[User] 
	SET	
	 [Email] = @Email    
	,[NatRegNbr] = @NatRegNbr
	,[LastName] = @LastName 
	,[FirstName] = @FirstName
	,[UserStatus] = @UserStatus
	WHERE [Id] = @Id;
END
