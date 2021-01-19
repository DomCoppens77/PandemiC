CREATE FUNCTION [dbo].[SF_GetHashPasswd]
(
	@Passwd NVARCHAR(20)
)
RETURNS BINARY(64)
AS
BEGIN
	return HASHBYTES('SHA2_512', [dbo].[SF_GetPreSalt]() + @Passwd + [dbo].[SF_GetPostSalt]());
END
