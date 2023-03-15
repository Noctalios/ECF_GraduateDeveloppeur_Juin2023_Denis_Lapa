-- =============================================
-- Author:		Lapa Denis
-- Create date: 26/02/2023
-- Description:	Save Menus made by Administrator
-- =============================================
CREATE PROCEDURE [dbo].[SaveMenus] 
	@Menus			MenuTableType READONLY,
	@MenusFormulas	MenuFormulaTable READONLY
AS
BEGIN
	SET NOCOUNT ON;

    -- DELETE Menus that have been removed

	DELETE FROM Menu_Formula
	FROM Menu_Formula MF
	LEFT JOIN @MenusFormulas AS MFT ON MF.MenuId = MFT.MenuId
	WHERE MFT.MenuId IS NULL

	DELETE Menu
	FROM Menu M
	LEFT JOIN @Menus AS MT ON M.Id = MT.Id
	WHERE MT.Id IS NULL

	-- INSERT New Menus that have been created
	
	INSERT INTO Menu
		SELECT MT.Label 
		FROM @Menus MT
		WHERE NOT EXISTS
			(SELECT Id
			 FROM Menu M
			 WHERE M.Id = MT.Id OR M.Label = MT.Label)

	INSERT INTO Menu_Formula
		SELECT MFT.MenuId, MFT.FormulaId
		FROM @MenusFormulas MFT
		WHERE NOT EXISTS
			(SELECT Id
			 FROM Menu_Formula MF
			 WHERE MF.MenuId = MFT.MenuId AND MF.FormulaId = MFT.FormulaId)

	INSERT INTO Menu_Formula
	SELECT M.Id, MFT.FormulaId
	FROM @MenusFormulas MFT
	LEFT JOIN Menu AS M ON M.[Label] = MFT.MenuLabel
	WHERE MFT.MenuLabel = M.[Label] AND MFT.MenuId <> M.Id

	--UPDATE Existing Menus

	UPDATE Menu
		SET [Label] = M.[Label]
		FROM @Menus M
		WHERE M.Id = Menu.Id
END