CREATE TABLE [dbo].[Users_Allergies]
(
	[Id]		 INT	NOT NULL,
	[UserId]	 INT	NOT NULL,
	[AllergieId] INT	NOT NULL,
	PRIMARY KEY (Id),
	CONSTRAINT FK_Users		FOREIGN KEY (UserId)		REFERENCES Users(Id),
	CONSTRAINT FK_Allergies FOREIGN KEY (AllergieId)	REFERENCES Allergies(Id)
)
