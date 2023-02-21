CREATE TABLE [dbo].[Menu_RestaurantMenu]
(
	[Id]		INT IDENTITY (1, 1),
	[RMId]		INT NOT NULL,
	[MenuId]	INT NOT NULL,
	PRIMARY KEY (Id),
	CONSTRAINT FK_MRM__RestaurantMenu	FOREIGN KEY (RMId)		REFERENCES RestaurantMenu(Id),
	CONSTRAINT FK_MRM__Menu				FOREIGN KEY (MenuId)	REFERENCES Menu(Id),
);