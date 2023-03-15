CREATE TABLE [dbo].[Menu_Formula] (
    [Id]        INT IDENTITY (1, 1) NOT NULL,
    [MenuId]    INT NOT NULL,
    [FormulaId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_MF__Formula] FOREIGN KEY ([FormulaId]) REFERENCES [dbo].[Formula] ([Id]),
    CONSTRAINT [FK_MF__Menu] FOREIGN KEY ([MenuId]) REFERENCES [dbo].[Menu] ([Id])
);

