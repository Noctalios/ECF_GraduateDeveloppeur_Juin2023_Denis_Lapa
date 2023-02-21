CREATE TABLE [dbo].[Booking_Allergies]
(
	[Id]			INT IDENTITY(1, 1),
	[BookingId]		INT NOT NULL,
	[AllergieId]	INT NOT NULL,	
	PRIMARY KEY (Id),
	CONSTRAINT FK_BA__Bookings			FOREIGN KEY (BookingId)		REFERENCES Bookings(Id),
	CONSTRAINT FK_BA__BookingAllergie	FOREIGN KEY (AllergieId)	REFERENCES Allergies(Id),
);