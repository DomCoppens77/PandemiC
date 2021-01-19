CREATE PROCEDURE [PandUser].[DCOSP_DelUser]
	@Id int
AS
BEGIN
	DELETE FROM [dbo].[User] Where [Id] = @Id;
END
