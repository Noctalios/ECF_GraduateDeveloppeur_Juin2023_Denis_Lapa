CREATE TABLE [dbo].[Formula_Constructor]
(
	[Id]			INT IDENTITY (1, 1),
	[FormulaId]		INT NOT NULL,
	[DishTypeId]	INT NOT NULL,
	PRIMARY KEY (Id),
	CONSTRAINT FK_FC__Formula	FOREIGN KEY (FormulaId)		REFERENCES Formula(Id),
	CONSTRAINT FK_FC__DishType	FOREIGN KEY (DishTypeId)	REFERENCES DishType(Id)
);