CREATE PROCEDURE [PandUser].[DCOSP_UpdTimeLine]
	@Id INT,
	@UserId INT,
	@RestaurantId INT,
	@DinerDate DATE,
	@NbrGuests INT
AS
BEGIN
	UPDATE [dbo].[TimeLine] 
	SET	
	 [RestaurantId]  =@RestaurantId,
	 [DinerDate] = @DinerDate,
	 [NbrGuests] = @NbrGuests
	WHERE [Id] = @Id AND [UserId] = @UserId;
END
