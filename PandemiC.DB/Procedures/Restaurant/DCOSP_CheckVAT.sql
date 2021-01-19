﻿CREATE PROCEDURE [PandUser].[DCOSP_CheckVAT]
	@VAT NVARCHAR(320), 
	@Id INT
AS
BEGIN
	IF Exists(SELECT * FROM [dbo].[Restaurant] WHERE [VAT] = @VAT AND [Id] != @Id)
		SELECT CONVERT(BIT, 1);
	ELSE
		SELECT CONVERT(BIT, 0);
END
