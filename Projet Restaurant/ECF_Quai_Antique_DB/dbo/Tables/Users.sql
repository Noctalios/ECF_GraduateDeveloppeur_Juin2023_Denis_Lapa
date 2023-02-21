CREATE TABLE [dbo].[Users]
(
	[Id]		INT				IDENTITY (1, 1),
	[Email]		VARCHAR(255)	NOT NULL,
	[Password]	VARCHAR(MAX)	NOT NULL,
	[Guest]		INT				NOT NULL,
	[RoleId]	INT				NOT NULL,
	PRIMARY KEY (Id),
	CONSTRAINT FK_UserRole FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);
