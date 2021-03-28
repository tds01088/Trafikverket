CREATE TABLE [dbo].[Elev_Betyg] (
    [id]      INT  IDENTITY (1, 1) NOT NULL,
    [elev_id] INT  NULL,
    [test]    TEXT NULL,
    [betyg]   INT  NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

