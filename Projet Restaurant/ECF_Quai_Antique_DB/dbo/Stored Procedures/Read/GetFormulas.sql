-- =============================================
-- Author:		Lapa Denis
-- Create date: 09/03/2023
-- Description:	Retrieve all Formulas
-- =============================================
CREATE PROCEDURE [dbo].[GetFormulas] 
AS
BEGIN
	SET NOCOUNT ON;

    -- Insert statements for procedure here
	SELECT Formula.Id, Formula.[Description], Formula.Price, DT.Id AS DishTypeId, DT.[Label] AS DishTypeLabel
	FROM Formula
	INNER JOIN Formula_DishType AS FDT ON FDt.FormulaId = Formula.Id
	INNER JOIN DishType AS DT ON FDT.DishTypeId = DT.Id
	ORDER BY Formula.Id
END