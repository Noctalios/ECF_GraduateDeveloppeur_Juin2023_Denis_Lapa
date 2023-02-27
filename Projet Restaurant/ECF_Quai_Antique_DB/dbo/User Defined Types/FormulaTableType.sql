CREATE TYPE [dbo].[FormulaTableType] AS TABLE (
    [Id]          INT             NOT NULL,
    [Description] VARCHAR (MAX)   NOT NULL,
    [Price]       DECIMAL (12, 2) NOT NULL);

