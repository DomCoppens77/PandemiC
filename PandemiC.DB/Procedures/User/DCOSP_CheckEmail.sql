CREATE PROCEDURE [PandUser].[DCOSP_CheckEmail]
	@Email NVARCHAR(320),
	@Id Int
AS
BEGIN
	IF Exists(SELECT * FROM [dbo].[User] WHERE [Email] = @Email AND [Id] != @Id)
		SELECT CONVERT(BIT, 1);
	ELSE
		SELECT CONVERT(BIT, 0);
END
