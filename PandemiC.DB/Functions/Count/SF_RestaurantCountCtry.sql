CREATE FUNCTION [dbo].[SF_RestaurantCountCtry]
(
	@ISO nvarchar(2)
)
RETURNS INT
AS
BEGIN
	DECLARE @Cnt int;
	SELECT @Cnt = count(*) from [dbo].[Restaurant] WHERE [dbo].[Restaurant].[Country] = UPPER(@ISO); 
	RETURN (@Cnt);
END