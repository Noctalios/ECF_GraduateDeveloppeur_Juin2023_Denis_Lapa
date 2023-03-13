-- =============================================
-- Author:		Lapa Denis
-- Create date: 08/03/2023
-- Description:	Retrieve all the dishTypes
-- =============================================
CREATE PROCEDURE GetDishTypes 
	-- Add the parameters for the stored procedure here

AS
BEGIN

	SET NOCOUNT ON;
	SELECT * FROM DishType
END