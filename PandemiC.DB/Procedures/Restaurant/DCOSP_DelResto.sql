CREATE PROCEDURE [PandUser].[DCOSP_DelResto]
	@Id INT
AS
BEGIN
	DELETE FROM [dbo].[Restaurant] Where [Id] = @Id;
END
