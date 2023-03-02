CREATE TABLE [dbo].[Formula]
(
	[Id]		  INT				IDENTITY (1, 1),
	[Description] VARCHAR(MAX)		NOT NULL,
	[Price]		  DECIMAL(12, 2)	NOT NULL,
	PRIMARY KEY (Id)
);