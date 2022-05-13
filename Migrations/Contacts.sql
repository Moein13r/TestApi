
    CREATE TABLE [dbo].[Contacts] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (10) NOT NULL,
    [PhoneNumber] NVARCHAR (13) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);