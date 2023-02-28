-- =============================================
-- Author:		<Lapa Denis>
-- Create date: <22/02/2023>
-- Description:	<Insert a new booking into the database>
-- =============================================
CREATE PROCEDURE [dbo].[CreateBooking]
	@Date		DATETIME,
	@Name		VARCHAR(50),
	@Guest		INT,
	@Allergens	AllergiesTableType READONLY
AS
	BEGIN
		SET NOCOUNT ON;

		--INSERT New Allergens if not exists

		INSERT INTO dbo.Allergies (Label)
		SELECT (Label) 
		FROM @Allergens A
		WHERE NOT EXISTS 
			(
				SELECT Label 
				FROM Allergies
				WHERE A.Label = Allergies.Label
			)

		--CREATE Booking
		IF NOT EXISTS (SELECT Id FROM Bookings WHERE Date = @Date AND Name = @Name AND Guest = @Guest)
		INSERT INTO [dbo].[Bookings] (Date, Name, Guest)
		VALUES (@Date, @Name, @Guest)


		--CREATE Booking allergens related

		INSERT INTO Booking_Allergies (BookingId, AllergieId)
			SELECT B.Id AS BookingId, Al.Id AS AllergenId
			FROM Bookings AS B
			CROSS JOIN @Allergens AS A
			INNER JOIN Allergies AS Al ON Al.Label = A.Label
			WHERE @Date = B.Date AND @Name = B.Name AND @Guest = B.Guest
	END