﻿CREATE TABLE [dbo].[Users_Allergies]
(
	[Id]		 INT	NOT NULL,
	[UserId]	 INT	NOT NULL,
	[AllergieId] INT	NOT NULL,
	PRIMARY KEY (Id),
	CONSTRAINT FK_UA__Users		FOREIGN KEY (UserId)		REFERENCES Users(Id),
	CONSTRAINT FK_UA__Allergies FOREIGN KEY (AllergieId)	REFERENCES Allergies(Id)
)
