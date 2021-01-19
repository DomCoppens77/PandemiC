CREATE TABLE [dbo].[User]
(
	[Id] INT IDENTITY NOT NULL, 
    [Email] NVARCHAR(320) NOT NULL UNIQUE,
    [NatRegNbr] NVARCHAR(50) NULL  UNIQUE,
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL,
    [Passwd] BINARY(64) NOT NULL,
    [UserStatus] INTEGER DEFAULT 1 NOT NULL,
    CONSTRAINT [PK_user_Id] PRIMARY KEY ([Id]) ,
    CONSTRAINT [UK_user_Email] UNIQUE ([Email]),
    CONSTRAINT [UK_user_NatRegNbr] UNIQUE ([NatRegNbr]),
)
GO

CREATE INDEX [IX_User_NatRegNbr] ON [dbo].[User] ([NatRegNbr])

GO