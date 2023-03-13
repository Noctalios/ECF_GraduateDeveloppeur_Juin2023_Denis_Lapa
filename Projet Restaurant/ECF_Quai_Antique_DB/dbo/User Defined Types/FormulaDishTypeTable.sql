CREATE TYPE [dbo].[FormulaDishTypeTable] AS TABLE (
    [FormulaId]     INT          NOT NULL,
    [DishTypeId]    INT          NOT NULL,
    [FormulaLabel]  VARCHAR(MAX) NOT NULL);

