CREATE TABLE [dbo].[IngredientTypes] (
    [Id]   BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (MAX) NULL,
    CONSTRAINT [PK_dbo.IngredientTypes] PRIMARY KEY CLUSTERED ([Id] ASC)
);

