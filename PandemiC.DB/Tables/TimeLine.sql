CREATE TABLE [dbo].[TimeLine]
(
	[Id] INT NOT NULL IDENTITY, 
	[UserId] INT NOT NULL,
	[RestaurantId] INT NOT NULL,
	[DinerDate] DATETIME2,
	[NbrGuests] INT NOT NULL DEFAULT 1
    CONSTRAINT [PK_TimeLine] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_TimeLine_Restaurant] FOREIGN KEY ([RestaurantId]) REFERENCES [Restaurant]([Id]) ,
	CONSTRAINT [FK_TimeLine_User] FOREIGN KEY ([UserId]) REFERENCES [User]([Id]) ,
)

GO

CREATE INDEX [IX_TimeLine_DinerDate] ON [dbo].[TimeLine] ([DinerDate])

GO

CREATE INDEX [IX_TimeLine_UserId] ON [dbo].[TimeLine] ([UserId])

GO

CREATE INDEX [IX_TimeLine_RestoDinerDate] ON [dbo].[TimeLine] ([RestaurantId],[DinerDate])

GO
