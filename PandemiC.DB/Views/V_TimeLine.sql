CREATE VIEW [PandUser].[V_TimeLine]
	AS SELECT 
	  [TimeLine].[Id]
	, [TimeLine].[UserId]
	, [TimeLine].[RestaurantId]
	, [Restaurant].[Name] as RestaurantName
	, [TimeLine].[DinerDate]
	, [TimeLine].[NbrGuests]
	FROM [TimeLine]
	INNER JOIN [Restaurant] ON [TimeLine].[RestaurantId] = [Restaurant].[Id] 