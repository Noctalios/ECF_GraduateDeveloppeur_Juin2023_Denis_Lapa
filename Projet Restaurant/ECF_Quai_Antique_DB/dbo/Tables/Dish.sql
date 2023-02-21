CREATE TABLE [dbo].[Dish]
(
	[Id]			INT				IDENTITY(1, 1),
	[DishTypeId]	INT				NOT NULL,
	[Description]	VARCHAR(MAX)	NOT NULL,
	[Price]			DECIMAL(12, 2)	NOT NULL,
	PRIMARY KEY (Id),
	CONSTRAINT FK_Dishes__DishType FOREIGN KEY (DishTypeId) REFERENCES DishType(Id),
);
