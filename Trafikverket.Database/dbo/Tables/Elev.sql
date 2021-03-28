CREATE TABLE [dbo].[Elev] (
    [id]        INT  IDENTITY (1, 1) NOT NULL,
    [firstname] TEXT NULL,
    [lastname]  TEXT NULL,
    [email]     TEXT NULL,
    [tele]      TEXT NULL,
    [birthdate] TEXT NULL,
    PRIMARY KEY CLUSTERED ([id] ASC)
);

