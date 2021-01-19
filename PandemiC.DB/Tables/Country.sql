CREATE TABLE [dbo].[Country]
(
	[ISO] NVARCHAR(2) NOT NULL, 
    [Ctry] NVARCHAR(20) NULL ,
	[IsEU] Bit default 0, 
    CONSTRAINT [PK_Country] PRIMARY KEY ([ISO]),
)
