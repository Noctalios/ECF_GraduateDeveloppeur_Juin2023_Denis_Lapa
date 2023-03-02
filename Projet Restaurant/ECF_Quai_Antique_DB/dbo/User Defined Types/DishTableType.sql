CREATE TYPE [dbo].[DishTableType] AS TABLE (
    [Id]          INT             NOT NULL,
    [Label]       VARCHAR (MAX)   NOT NULL,
    [DishTypeId]  INT             NOT NULL,
    [Description] VARCHAR (MAX)   NOT NULL,
    [Price]       DECIMAL (12, 2) NOT NULL);

