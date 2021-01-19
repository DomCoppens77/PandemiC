CREATE PROCEDURE [PandUser].[DCOSP_ChkResto]
	@Id int = 0
AS
BEGIN
	DECLARE @Cnt INT;
	SET @Cnt = [dbo].[SF_TLRestoCount](@Id);
	SELECT @Cnt;
END
