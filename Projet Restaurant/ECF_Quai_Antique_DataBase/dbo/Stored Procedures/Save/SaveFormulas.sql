-- =============================================
-- Author:		Lapa Denis
-- Create date: 26/02/2023
-- Description:	Delete, Insert, Update Formulas
-- =============================================
CREATE PROCEDURE [dbo].[SaveFormulas] 
	-- Add the parameters for the stored procedure here
	@Formulas			FormulaTableType READONLY, 
	@FormulasDishType	FormulaDishTypeTable READONLY
AS
BEGIN
	--DELETE Formulas that have been remove by administrator whith all records related to formulas
	DELETE FROM Menu_Formula
	FROM Menu_Formula MF
	LEFT JOIN @FormulasDishType AS FDTT ON FDTT.FormulaId = MF.FormulaId
	WHERE FDTT.FormulaId IS NULL

	DELETE Formula_DishType
	FROM Formula_DishType FDT
	LEFT JOIN @FormulasDishType AS FDTT ON FDTT.FormulaId = FDT.FormulaId AND FDTT.DishTypeId = FDT.DishTypeId
	WHERE FDTT.FormulaId IS NULL 

	DELETE Formula
	FROM Formula F
	LEFT JOIN @Formulas AS FT ON F.Id = FT.Id
	WHERE FT.Id IS NULL

	-- INSERT New Formulas

	INSERT INTO Formula
	SELECT FT.Description, FT.Price
	FROM @Formulas FT
	WHERE NOT EXISTS
		(SELECT Id
		 FROM Formula F
		 WHERE F.Id = FT.Id OR F.Description = FT.Description)

	INSERT INTO Formula_DishType
	SELECT FDTT.FormulaId, FDTT.DishTypeId
	FROM @FormulasDishType FDTT
	WHERE NOT EXISTS
		(SELECT Id
		 FROM Formula_DishType FDT
		 WHERE FDT.FormulaId = FDTT.FormulaId AND FDT.DishTypeId = FDTT.DishTypeId)

	INSERT INTO Formula_DishType
	SELECT F.Id, FDTT.DishTypeId
	FROM @FormulasDishType FDTT
	LEFT JOIN Formula AS F ON F.[Description] = FDTT.FormulaLabel
	WHERE FDTT.FormulaLabel = F.Description AND FDTT.FormulaId <> F.Id

	-- UPDATE existing formulas

	UPDATE Formula
	SET [Description] = FT.[Description],
		[Price] = FT.[Price]
	FROM @Formulas FT
	WHERE FT.Id = Formula.Id

END