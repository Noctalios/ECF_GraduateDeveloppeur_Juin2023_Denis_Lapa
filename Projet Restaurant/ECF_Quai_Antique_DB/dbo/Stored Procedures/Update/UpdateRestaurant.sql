-- =============================================
-- Author:		Lapa Denis
-- Create date: 23/02/2023
-- Description:	Update Restaurant with the new periods of workingdays and Guest
-- =============================================
CREATE PROCEDURE [dbo].[UpdateRestaurant]
	@RestaurantId	INT,
	@Guest			INT,
	@Periods		PeriodsTableType READONLY
AS
	BEGIN

		--UPDATE the guest of the Restaurant
		SET NOCOUNT ON;
		UPDATE Restaurant
		SET Guest = @Guest
		WHERE Id = @RestaurantId

		--UPDATE the Periods for the Restaurant
		UPDATE dbo.Periods 
		SET [Open] = P.[Open], 
			[Close] = P.[Close],
			[IsActive] = P.[IsActive]
		FROM @Periods P
		WHERE Periods.Id = P.Id
	END