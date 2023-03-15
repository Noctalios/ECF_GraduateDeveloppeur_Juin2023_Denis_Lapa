CREATE TABLE [dbo].[Users] (
    [Id]       INT           IDENTITY (1, 1) NOT NULL,
    [Email]    VARCHAR (255) NOT NULL,
    [Password] VARCHAR (MAX) NOT NULL,
    [Guest]    INT           NULL,
    [RoleId]   INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User__Role] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id])
);

