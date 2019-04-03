CREATE TABLE [dbo].[Brands] (
    [Id]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.Brands] PRIMARY KEY CLUSTERED ([Id] ASC)
);

