CREATE PROCEDURE [PandUser].[DCOSP_DelTimeLine]
	@Id INT, 
	@UserId INT
AS
BEGIN
	DELETE FROM [dbo].[TimeLine] Where [Id] = @Id AND [UserId] = @UserId;
END
