﻿CREATE TABLE [dbo].[Periods]
(
	[Id]			INT				IDENTITY (0, 1),
	[DayId]			INT				NOT NULL,
	[RestaurantId]	INT				NOT NULL,
	[Open]			DECIMAL(10, 2)	NULL,
	[Close]			DECIMAL(10, 2)	NULL,
    PRIMARY KEY (Id),
	CONSTRAINT FK_Periods__Days			FOREIGN KEY (DayId)			REFERENCES Days(Id),
	CONSTRAINT FK_Periods__Restaurant	FOREIGN KEY (RestaurantId)	REFERENCES Restaurant(Id)
)