CREATE PROCEDURE [PandUser].[DCOSP_DelCtry]
	@ISO NVARCHAR(2)
AS
BEGIN
   if ([dbo].[SF_RestaurantCountCtry](UPPER(@ISO))) = 0
	DELETE FROM [Country] Where [ISO] = UPPER(@ISO);
END