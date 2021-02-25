CREATE PROCEDURE [PandUser].[DCOSP_DelResto]
	@Id INT
AS
BEGIN
	if ([dbo].[SF_TLRestoCount](@Id)) = 0
	  DELETE FROM [dbo].[Restaurant] Where [Id] = @Id;
END
