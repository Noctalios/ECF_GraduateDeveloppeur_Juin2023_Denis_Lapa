CREATE TABLE [dbo].[Days]
(
	[Id]			INT IDENTITY (1, 1),
	[Label]			VARCHAR(10) NOT NULL,
	[RestaurantId]	INT			NOT NULL,
	PRIMARY KEY (Id),
	CONSTRAINT FK_Days__Restaurant FOREIGN KEY (RestaurantId) REFERENCES Restaurant(Id)
)
