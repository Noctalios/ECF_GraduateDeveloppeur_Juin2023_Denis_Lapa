-- =============================================
-- Author:		Lapa Denis
-- Create date: 23/02/2023
-- Description:	Retrieve the Restaurant data with work days and guest
-- =============================================
CREATE PROCEDURE [dbo].[GetRestaurant] 
AS
	BEGIN
		SET NOCOUNT ON;
		SELECT R.Id, R.Label, Guest, D.Id AS DayId, P.Id AS PeriodId, P.[Open], P.[Close]
		FROM [dbo].[Restaurant] AS R
		LEFT JOIN [dbo].[Periods] AS P ON R.Id = P.RestaurantId
		INNER JOIN [dbo].Days AS D ON D.Id = P.DayId
	END