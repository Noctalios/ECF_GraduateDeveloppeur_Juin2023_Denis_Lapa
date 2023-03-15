CREATE TABLE [dbo].[Restaurant] (
    [Id]    INT          IDENTITY (1, 1) NOT NULL,
    [Label] VARCHAR (50) NOT NULL,
    [Guest] INT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

