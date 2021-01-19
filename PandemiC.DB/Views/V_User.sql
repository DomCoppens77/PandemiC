CREATE VIEW [PandUser].[V_User]
	AS SELECT 
	[Id] , 
    [Email] ,
    [NatRegNbr] ,
    [FirstName] , 
    [LastName] ,
    [UserStatus] 
	FROM [User]
