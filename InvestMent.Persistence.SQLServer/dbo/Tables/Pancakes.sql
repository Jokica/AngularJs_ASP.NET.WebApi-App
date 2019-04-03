CREATE TABLE [dbo].[Pancakes] (
    [Id]       BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (MAX) NULL,
    [ImageURL] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Pancakes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

