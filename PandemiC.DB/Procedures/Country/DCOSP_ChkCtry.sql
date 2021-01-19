CREATE PROCEDURE [PandUser].[DCOSP_ChkCtry]
	@ISO NVARCHAR(3)
AS
BEGIN
	DECLARE @Cnt INT;
	SET @Cnt = [dbo].[SF_RestaurantCountCtry](UPPER(@ISO));
	SELECT @Cnt;
END
