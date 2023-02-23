CREATE TABLE [dbo].[Periods]
(
	[Id]	INT NOT NULL,
	[DayId] INT NOT NULL,
	[Open]	DECIMAL(2, 2) NULL,
	[Close]	DECIMAL(2, 2) NULL,
    PRIMARY KEY (Id),
	CONSTRAINT FK_Periods__Days FOREIGN KEY (DayId) REFERENCES Days(Id) 
)
