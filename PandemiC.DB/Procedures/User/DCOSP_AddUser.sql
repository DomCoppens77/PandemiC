CREATE PROCEDURE [PandUser].[DCOSP_AddUser]
	@Email        NVARCHAR(20),
	@NatRegNbr    NVARCHAR(50),
	@Passwd       NVARCHAR(20),
	@LastName     NVARCHAR(50),
	@FirstName    NVARCHAR(50)
AS
BEGIN
	INSERT INTO [dbo].[User] ([Email], [NatRegNbr], [Passwd],[LastName], [FirstName]) 
    OUTPUT inserted.Id
    VALUES(@Email, @NatRegNbr,[dbo].[SF_GetHashPasswd](@Passwd), @LastName, @FirstName);
END

