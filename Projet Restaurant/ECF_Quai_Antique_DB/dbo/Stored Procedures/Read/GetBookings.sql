-- =============================================
-- Author:		Lapa Denis
-- Create date: 23/02/2023
-- Description:	Retrive all the bookings for administrators
-- =============================================
CREATE PROCEDURE [dbo].[GetBookings] 
AS
BEGIN
	SET NOCOUNT ON;
	SELECT B.Id, B.Date, B.Name, B.Guest, A.Id AS AllergieId, A.Label AS AllergieLabel
	FROM Bookings AS B
	LEFT JOIN Booking_Allergies AS BA ON B.Id = BA.BookingId 
	LEFT JOIN Allergies AS A ON A.Id = BA.AllergieId
END