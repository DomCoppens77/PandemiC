CREATE PROCEDURE [PandUser].[DCOSP_AddCtry]
	@ISO NVARCHAR(2),
	@Ctry NVARCHAR(20),
	@IsEU BIT
AS
BEGIN
	Insert into [Country]([ISO],[Ctry],IsEU) 
    values(UPPER(@ISO),RTRIM(@Ctry),@IsEU);
END
