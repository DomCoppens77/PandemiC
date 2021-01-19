CREATE FUNCTION [dbo].[SF_TLRestoCount]
(
	@Id INT
)
RETURNS INT
AS
BEGIN
	DECLARE @Cnt int;
	SELECT @Cnt = count(*) from [dbo].[TimeLine] WHERE [dbo].[TimeLine].[RestaurantId]  =@Id; 
	RETURN (@Cnt);
END
