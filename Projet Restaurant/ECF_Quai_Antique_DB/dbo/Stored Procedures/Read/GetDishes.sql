-- =============================================
-- Author:		Lapa Denis
-- Create date: 24/02/2023
-- Description:	Retrieve all the dishes
-- =============================================
CREATE PROCEDURE [dbo].[GetDishes] 
AS
BEGIN
	SET NOCOUNT ON;

	SELECT D.Id, D.Label, D.Description, D.Price, DT.Id AS DishTypeId, DT.Label AS DishTypeLabel
	FROM Dish AS D
	LEFT JOIN DishType AS DT ON D.DishTypeId = DT.Id
END