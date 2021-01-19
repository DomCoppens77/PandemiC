CREATE PROCEDURE [PandUser].[DCOSP_UpdResto]
	@Id           INT,
	@VAT          NVARCHAR(50),
	@Name         NVARCHAR(20),
	@Address1     NVARCHAR(255),
	@Address2     NVARCHAR(255),
	@Zip          NVARCHAR(15),
	@City         NVARCHAR(30),
	@Country      NVARCHAR(2),
	@Email        NVARCHAR(320),
	@Closed       BIT
AS
BEGIN
	UPDATE [dbo].[Restaurant] 
	SET	
	[VAT] = @VAT     
	,[Name] = @Name    
	,[Address1] = @Address1
	,[Address2] = @Address2
	,[ZIP] = @Zip     
	,[City] = @City    
	,[Country] = UPPER(@Country)
	,[Email] = @Email   
	,[Closed] = @Closed  
	WHERE [Id] = @Id;
END
