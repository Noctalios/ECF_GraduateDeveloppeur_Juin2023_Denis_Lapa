CREATE TYPE [dbo].[PeriodsTableType] AS TABLE (
    [Id]       INT      NOT NULL,
    [Open]     DATETIME NOT NULL,
    [Close]    DATETIME NOT NULL,
    [IsActive] BIT      NOT NULL);

