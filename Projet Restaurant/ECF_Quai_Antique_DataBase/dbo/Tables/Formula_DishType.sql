CREATE TABLE [dbo].[Formula_DishType] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [FormulaId]  INT NOT NULL,
    [DishTypeId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_FDT__DishType] FOREIGN KEY ([FormulaId]) REFERENCES [dbo].[Formula] ([Id]),
    CONSTRAINT [FK_FDT__Formula] FOREIGN KEY ([DishTypeId]) REFERENCES [dbo].[DishType] ([Id])
);

