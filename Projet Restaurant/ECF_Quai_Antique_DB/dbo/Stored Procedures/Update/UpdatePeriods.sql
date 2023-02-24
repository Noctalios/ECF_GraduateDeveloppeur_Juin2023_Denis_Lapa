-- =============================================
-- Author:		Lapa Denis
-- Create date: 23/02/2023
-- Description:	Update periods with the new periods of workingdays
-- =============================================
CREATE PROCEDURE UpdatePeriods
	@Periods	PeriodsTableType READONLY
AS
	BEGIN
		SET NOCOUNT ON;
		UPDATE dbo.Periods 
		SET [Open] = P.[Open], 
			[Close] = P.[Close]
		FROM @Periods P
		WHERE Periods.Id = P.Id
	END