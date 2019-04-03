CREATE TABLE [dbo].[Ingredients] (
    [Id]                BIGINT         IDENTITY (1, 1) NOT NULL,
    [Name]              NVARCHAR (MAX) NULL,
    [IngredientBrandId] BIGINT         NULL,
    [TypeId]            BIGINT         NOT NULL,
    CONSTRAINT [PK_dbo.Ingredients] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_dbo.Ingredients_dbo.Brands_IngredientBrandId] FOREIGN KEY ([IngredientBrandId]) REFERENCES [dbo].[Brands] ([Id]),
    CONSTRAINT [FK_dbo.Ingredients_dbo.IngredientTypes_TypeId] FOREIGN KEY ([TypeId]) REFERENCES [dbo].[IngredientTypes] ([Id]) ON DELETE CASCADE
);


GO
CREATE NONCLUSTERED INDEX [IX_TypeId]
    ON [dbo].[Ingredients]([TypeId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_IngredientBrandId]
    ON [dbo].[Ingredients]([IngredientBrandId] ASC);

