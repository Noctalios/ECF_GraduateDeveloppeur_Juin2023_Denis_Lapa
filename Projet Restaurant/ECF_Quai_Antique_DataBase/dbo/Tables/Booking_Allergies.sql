CREATE TABLE [dbo].[Booking_Allergies] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [BookingId]  INT NOT NULL,
    [AllergieId] INT NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_BA__Allergies] FOREIGN KEY ([AllergieId]) REFERENCES [dbo].[Allergies] ([Id]),
    CONSTRAINT [FK_BA__Bookings] FOREIGN KEY ([BookingId]) REFERENCES [dbo].[Bookings] ([Id])
);

