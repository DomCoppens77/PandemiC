CREATE PROCEDURE [PandUser].[DCO_CheckUserNatRegNbr]
	@NatRegNbr NVARCHAR(50),
	@Passwd NVARCHAR(20)
AS
BEGIN
	SELECT [Id], [Email], [NatRegNbr], [LastName], [FirstName] , [UserStatus]
	FROM [dbo].[User] WHERE [NatRegNbr] = @NatRegNbr
	AND [Passwd] = [dbo].[SF_GetHashPasswd](@Passwd);
END
