CREATE TABLE [dbo].[Restaurant]
(
	[Id] INT IDENTITY NOT NULL, 
	[VAT] NVARCHAR(50) NOT NULL UNIQUE,
	[Name] NVARCHAR(50) NOT NULL,
	[Address1] NVARCHAR(255),
	[Address2] NVARCHAR(255),
	[ZIP] NVARCHAR(15),
	[City] NVARCHAR(30),
	[Country] NVARCHAR(2) NOT NULL,
	[Email] NVARCHAR(320),
	[Closed] BIT default 1
    CONSTRAINT [PK_Restaurant] PRIMARY KEY ([Id]) NOT NULL,
	CONSTRAINT [UK_Restaurant_VAT] unique ([VAT]),
)
