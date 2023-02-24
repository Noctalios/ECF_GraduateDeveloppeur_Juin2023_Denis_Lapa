CREATE TABLE [dbo].[Formula_DishType]
(
	[Id]			INT IDENTITY(1, 1),
	[FormulaId]		INT NOT NULL,
	[DishTypeId]	INT NOT NULL
	PRIMARY KEY(Id)
	CONSTRAINT FK_FDT__DishType FOREIGN KEY (FormulaId) REFERENCES Formula(Id),
	CONSTRAINT FK_FDT__Formula FOREIGN KEY (DishTypeId) REFERENCES DishType(Id)
)
