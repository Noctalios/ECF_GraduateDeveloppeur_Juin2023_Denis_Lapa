CREATE TABLE [dbo].[Users_Allergies] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [UserId]     INT NOT NULL,
    [AllergieId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UA__Allergies] FOREIGN KEY ([AllergieId]) REFERENCES [dbo].[Allergies] ([Id]),
    CONSTRAINT [FK_UA__Users] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id])
);

