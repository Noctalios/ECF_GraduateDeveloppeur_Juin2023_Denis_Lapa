-- =============================================
-- Author:		Lapa Denis
-- Create date: 24/02/2023
-- Description:	Insert the dishes and Update in database
-- =============================================
CREATE PROCEDURE [dbo].[SaveDishes] 
	-- Add the parameters for the stored procedure here
	@Dishes DishTableType READONLY
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

	-- DELETE Dish that have been remove by the Administrator
	DELETE Dish 
	FROM Dish D
	LEFT JOIN @Dishes AS DI ON D.Id = DI.Id
	WHERE DI.Id IS NULL

    -- INSERT Dishes

	INSERT INTO Dish
	SELECT Label, DishTypeId, Description, Price
	FROM @Dishes DI
	WHERE NOT EXISTS 
		(SELECT Id
		 FROM Dish D
		 WHERE D.Id = DI.Id OR D.Label = DI.Label)

	--UPDATE Existing dishes

	UPDATE dbo.Dish 
	SET [Label] = DI.[Label],
		[DishTypeId] = DI.[DishTypeId],
		[Description] = DI.[Description],
		[Price] = DI.[Price]
	FROM @Dishes DI
	WHERE DI.Id = Dish.Id
END