CREATE TABLE [dbo].[Periods] (
    [Id]           INT      IDENTITY (0, 1) NOT NULL,
    [DayId]        INT      NOT NULL,
    [RestaurantId] INT      NOT NULL,
    [Open]         DATETIME NOT NULL,
    [Close]        DATETIME NOT NULL,
    [IsActive]     BIT      NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Periods__Days] FOREIGN KEY ([DayId]) REFERENCES [dbo].[Days] ([Id]),
    CONSTRAINT [FK_Periods__Restaurant] FOREIGN KEY ([RestaurantId]) REFERENCES [dbo].[Restaurant] ([Id])
);

