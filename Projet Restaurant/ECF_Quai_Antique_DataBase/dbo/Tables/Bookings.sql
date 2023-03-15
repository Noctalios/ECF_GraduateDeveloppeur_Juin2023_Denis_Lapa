CREATE TABLE [dbo].[Bookings] (
    [Id]    INT          IDENTITY (1, 1) NOT NULL,
    [Date]  DATETIME     NOT NULL,
    [Name]  VARCHAR (50) NOT NULL,
    [Guest] INT          NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

