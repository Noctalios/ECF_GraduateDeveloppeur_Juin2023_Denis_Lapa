﻿CREATE TABLE [dbo].[Restaurant] 
(
    [Id]    INT          IDENTITY (1, 1),
    [Name]  VARCHAR (50) NOT NULL,
    [Guest] INT          NOT NULL,
    PRIMARY KEY (Id),
);

