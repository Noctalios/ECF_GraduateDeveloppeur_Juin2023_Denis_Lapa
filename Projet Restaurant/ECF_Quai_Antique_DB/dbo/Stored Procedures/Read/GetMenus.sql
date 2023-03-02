-- =============================================
-- Author:		Lapa Denis
-- Create date: 
-- Description:	Retrieve menus for the whole restaurant menu
-- =============================================
CREATE PROCEDURE GetMenus
AS
BEGIN
	SET NOCOUNT ON;
	SELECT 
	M.Id			AS MenuId, 
	M.Label			AS MenuLabel,
	F.Id			AS FormulaId,
	F.Description	AS FormulaDescription,
	F.Price			AS FormulaPrice,
	D.Id			AS DishId,
	D.Label			AS DishTypeLabel
	FROM Menu AS M
	INNER JOIN Menu_Formula		AS MF	ON M.Id = MF.MenuId
	INNER JOIN Formula			AS F	ON F.Id = MF.FormulaId
	INNER JOIN Formula_DishType AS FDT	ON F.Id = FDT.FormulaId
	INNER JOIN DishType			AS D	ON D.Id = FDT.DishTypeId
	ORDER BY MenuId, FormulaId, DishTypeId
END