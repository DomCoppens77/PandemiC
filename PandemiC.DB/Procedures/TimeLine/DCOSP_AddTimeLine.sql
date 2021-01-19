CREATE PROCEDURE [PandUser].[DCOSP_AddTimeLine]
	@UserId INT,
	@RestaurantId INT,
	@DinerDate DATE,
	@NbrGuests INT
AS
BEGIN
	INSERT INTO [dbo].[TimeLine] ([UserId],[RestaurantId],[DinerDate],[NbrGuests])
	OUTPUT inserted.Id
	VALUES(@UserId, @RestaurantId,@DinerDate,@NbrGuests)
END
