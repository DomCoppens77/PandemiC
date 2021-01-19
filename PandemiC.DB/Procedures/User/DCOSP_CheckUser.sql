CREATE PROCEDURE [PandUser].[DCOSP_CheckUser]
	@Email NVARCHAR(320),
	@Passwd NVARCHAR(20)
AS
BEGIN
	SELECT [Id], [Email], [NatRegNbr], [LastName], [FirstName] , [UserStatus]
	FROM [dbo].[User] WHERE [Email] = @Email 
	AND [Passwd] = [dbo].[SF_GetHashPasswd](@Passwd);
END
