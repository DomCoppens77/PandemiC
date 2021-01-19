CREATE PROCEDURE [PandUser].[DCOSP_AddResto]
	@VAT      NVARCHAR(50),
	@Name     NVARCHAR(20),
	@Address1 NVARCHAR(255),
	@Address2 NVARCHAR(255),
	@Zip      NVARCHAR(15),
	@City     NVARCHAR(30),
	@Country  NVARCHAR(2),
	@Email    NVARCHAR(320),
	@Closed   BIT
AS
BEGIN
	Insert into [dbo].[Restaurant] ([VAT],[Name],[Address1],[Address2],[ZIP],[City],[Country],[Email],[Closed])
    output inserted.Id
    values(@VAT,@Name,@Address1,@Address2,@Zip,@City,UPPER(@Country),@Email,@Closed);
END