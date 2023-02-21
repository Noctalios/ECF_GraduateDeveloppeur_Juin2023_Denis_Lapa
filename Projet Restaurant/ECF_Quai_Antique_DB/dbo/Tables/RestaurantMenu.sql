CREATE TABLE [dbo].[RestaurantMenu]
(
	[Id]		INT			IDENTITY (1, 1),
	[Label]		VARCHAR(50) NOT NULL,
	[IsActive]	INT			NOT NULL,
	PRIMARY KEY (Id)
);