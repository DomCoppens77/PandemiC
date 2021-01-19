CREATE PROCEDURE [PandUser].[DCOSP_UpdUserUser]
	@Id           INT,
	@Email        NVARCHAR(20),
	@NatRegNbr    NVARCHAR(50),
	@LastName     NVARCHAR(50),
	@FirstName    NVARCHAR(50)
AS
BEGIN
	UPDATE [dbo].[User] 
	SET	
	 [Email] = @Email    
	,[LastName] = @LastName 
	,[FirstName] = @FirstName
	WHERE [Id] = @Id AND [NatRegNbr] = @NatRegNbr;
END
