CREATE PROCEDURE [PandUser].[DCOSP_CheckNatRegNbr]
	@NatRegNbr NVARCHAR(50),
	@Id Int
AS
BEGIN
	IF Exists(SELECT * FROM [dbo].[User] WHERE [NatRegNbr] = @NatRegNbr AND [Id] != @Id)
		SELECT CONVERT(BIT, 1);
	ELSE
		SELECT CONVERT(BIT, 0);
END
